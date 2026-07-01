using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Application.Interfaces.Services;
using LinkUp.Core.Application.DTOs.Friends;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Interfaces;

namespace LinkUp.Core.Application.Services;

public class AmistadService : IAmistadService
{
    private readonly IGenericRepository<Amistad> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AmistadService(IGenericRepository<Amistad> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository; _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<AmigoDto>> GetAmigosPorUsuarioAsync(string usuarioId)
    {
        var todas = await _repository.GetAllAsync();

        var amistadesActivas = todas.Where(a =>
            !a.IsDeleted &&
            (a.Usuario1Id == usuarioId || a.Usuario2Id == usuarioId)).ToList();

        var listaAmigos = new List<AmigoDto>();

        foreach (var amistad in amistadesActivas)
        {
            var esUsuario1 = amistad.Usuario1Id == usuarioId;
            var amigo = esUsuario1 ? amistad.Usuario2 : amistad.Usuario1;

            if (amigo != null) 
            {
                listaAmigos.Add(new AmigoDto
                {
                    AmistadId = amistad.Id,
                    AmigoId = amigo.Id,
                    NombreAmigo = $"{amigo.Nombre} {amigo.Apellido}",
                    FotoAmigoUrl = amigo.FotoPerfilUrl,
                    AmigosDesde = amistad.CreatedAt
                });
            }
        }

        return listaAmigos;
    }

    public async Task EliminarAmigoAsync(int amistadId, string usuarioId)
    {
        var amistad = await _repository.GetByIdAsync(amistadId);

        if (amistad != null && (amistad.Usuario1Id == usuarioId || amistad.Usuario2Id == usuarioId))
        {
            amistad.IsDeleted = true; 
            await _repository.UpdateAsync(amistad);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
