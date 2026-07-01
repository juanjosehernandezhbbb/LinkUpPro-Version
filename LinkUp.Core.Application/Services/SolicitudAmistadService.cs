using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Application.Interfaces.Services;
using LinkUp.Core.Application.DTOs.Friends;
using LinkUp.Core.Application.Common;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Enums;
using LinkUp.Core.Domain.Interfaces;
using AutoMapper;

namespace LinkUp.Core.Application.Services;

public class SolicitudAmistadService : ISolicitudAmistadService
{
    private readonly IGenericRepository<SolicitudAmistad> _solicitudRepo;
    private readonly IGenericRepository<Amistad> _amistadRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SolicitudAmistadService(
        IGenericRepository<SolicitudAmistad> solicitudRepo,
        IGenericRepository<Amistad> amistadRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _solicitudRepo = solicitudRepo; _amistadRepo = amistadRepo; _unitOfWork = unitOfWork; _mapper = mapper;
    }

    public async Task<Result<bool>> EnviarSolicitudAsync(string emisorId, string receptorId)
    {
        if (emisorId == receptorId) return Result<bool>.Failure("No puedes enviarte solicitud a ti mismo.");

        var solicitud = new SolicitudAmistad { EmisorId = emisorId, ReceptorId = receptorId, Estado = EstadoSolicitud.Pendiente };
        await _solicitudRepo.AddAsync(solicitud);
        await _unitOfWork.SaveChangesAsync();
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> ResponderSolicitudAsync(int solicitudId, string receptorId, bool aceptar)
    {
        var solicitud = await _solicitudRepo.GetByIdAsync(solicitudId);
        if (solicitud == null || solicitud.ReceptorId != receptorId || solicitud.Estado != EstadoSolicitud.Pendiente)
            return Result<bool>.Failure("Solicitud no válida.");

        solicitud.Estado = aceptar ? EstadoSolicitud.Aceptada : EstadoSolicitud.Rechazada;
        await _solicitudRepo.UpdateAsync(solicitud);

        if (aceptar)
        {
            // Creamos el vínculo de amistad en la base de datos
            var nuevaAmistad = new Amistad { Usuario1Id = solicitud.EmisorId, Usuario2Id = solicitud.ReceptorId, Estado = EstadoAmistad.Activa };
            await _amistadRepo.AddAsync(nuevaAmistad);
        }

        await _unitOfWork.SaveChangesAsync();
        return Result<bool>.Success(true);
    }

    public async Task<Result<IReadOnlyList<SolicitudAmistadDto>>> GetPendientesPorUsuarioAsync(string usuarioId)
    {
        var todas = await _solicitudRepo.GetAllAsync();
        var pendientes = todas.Where(s => s.ReceptorId == usuarioId && s.Estado == EstadoSolicitud.Pendiente).ToList();
        return Result<IReadOnlyList<SolicitudAmistadDto>>.Success(_mapper.Map<List<SolicitudAmistadDto>>(pendientes));
    }
}
