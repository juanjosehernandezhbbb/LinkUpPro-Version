using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Application.Interfaces.Services;
using LinkUp.Core.Application.DTOs.Posts;
using LinkUp.Core.Application.Common;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Interfaces;

namespace LinkUp.Core.Application.Services;

public class ReaccionService : IReaccionService
{
    private readonly IGenericRepository<Reaccion> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ReaccionService(IGenericRepository<Reaccion> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository; _unitOfWork = unitOfWork;
    }

    public async Task<Result<bool>> ToggleReaccionAsync(CrearReaccionDto dto)
    {
        var todas = await _repository.GetAllAsync();
        var reaccionExistente = todas.FirstOrDefault(r => r.PublicacionId == dto.PublicacionId && r.UsuarioId == dto.UsuarioId);

        if (reaccionExistente != null)
        {
            if (reaccionExistente.Tipo == dto.Tipo)
            {
                await _repository.DeleteAsync(reaccionExistente);
            }
            else
            {
                reaccionExistente.Tipo = dto.Tipo;
                await _repository.UpdateAsync(reaccionExistente);
            }
        }
        else
        {
            var nuevaReaccion = new Reaccion { PublicacionId = dto.PublicacionId, UsuarioId = dto.UsuarioId, Tipo = dto.Tipo };
            await _repository.AddAsync(nuevaReaccion);
        }

        await _unitOfWork.SaveChangesAsync();
        return Result<bool>.Success(true);
    }
}