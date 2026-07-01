using LinkUp.Core.Application.Interfaces.Services;
using LinkUp.Core.Application.DTOs.Battleship;
using LinkUp.Core.Application.Common;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Enums;
using LinkUp.Core.Domain.Interfaces;

namespace LinkUp.Core.Application.Services;

public class BattleshipService : IBattleshipService
{
    private readonly IGenericRepository<PartidaBattleship> _partidaRepo;
    private readonly IGenericRepository<Ataque> _ataqueRepo;
    private readonly IUnitOfWork _unitOfWork;

    public BattleshipService(
        IGenericRepository<PartidaBattleship> partidaRepo,
        IGenericRepository<Ataque> ataqueRepo,
        IUnitOfWork unitOfWork)
    {
        _partidaRepo = partidaRepo;
        _ataqueRepo = ataqueRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> CrearPartidaAsync(CrearPartidaDto dto)
    {
        try
        {
            var nuevaPartida = new PartidaBattleship
            {
                Jugador1Id = dto.Jugador1Id,
                Jugador2Id = dto.Jugador2Id,
                TurnoActualUsuarioId = dto.Jugador1Id, 
                Estado = EstadoPartida.EnProgreso,
                FechaInicio = DateTime.UtcNow,        
                TurnoAsignadoEn = DateTime.UtcNow     
            };

            await _partidaRepo.AddAsync(nuevaPartida);
            await _unitOfWork.SaveChangesAsync();

            return Result<int>.Success(nuevaPartida.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Failure($"Error al iniciar partida: {ex.Message}");
        }
    }

    public async Task<Result<AtaqueResponseDto>> AtacarAsync(RealizarAtaqueDto dto)
    {
        try
        {
            var partida = await _partidaRepo.GetByIdAsync(dto.PartidaId);
            if (partida == null || partida.Estado != EstadoPartida.EnProgreso)
                return Result<AtaqueResponseDto>.Failure("La partida no existe o ya ha finalizado.");

            if (partida.TurnoActualUsuarioId != dto.AtacanteId)
                return Result<AtaqueResponseDto>.Failure("No es tu turno de atacar.");

            var todosLosAtaques = await _ataqueRepo.GetAllAsync();
            var yaAtacado = todosLosAtaques.Any(a =>
                a.PartidaId == dto.PartidaId &&
                a.AtacanteId == dto.AtacanteId &&
                a.Fila == dto.Fila &&
                a.Columna == dto.Columna);

            if (yaAtacado)
                return Result<AtaqueResponseDto>.Failure("Ya has atacado esta coordenada previamente.");

            var resultadoCalculado = (dto.Fila + dto.Columna) % 2 == 0
                ? ResultadoAtaque.Impacto
                : ResultadoAtaque.Agua;

            var nuevoAtaque = new Ataque
            {
                PartidaId = dto.PartidaId,
                AtacanteId = dto.AtacanteId,
                Fila = dto.Fila,
                Columna = dto.Columna,
                Resultado = resultadoCalculado,
                FechaAtaque = DateTime.UtcNow
            };
            await _ataqueRepo.AddAsync(nuevoAtaque);

            var response = new AtaqueResponseDto
            {
                EsTurnoValido = true,
                Resultado = resultadoCalculado,
                PartidaTerminada = false
            };

            if (resultadoCalculado == ResultadoAtaque.Agua)
            {
                partida.TurnoActualUsuarioId = partida.Jugador1Id == dto.AtacanteId
                    ? partida.Jugador2Id
                    : partida.Jugador1Id;

                partida.TurnoAsignadoEn = DateTime.UtcNow; 
                response.Mensaje = "¡Agua! Turno del oponente.";
            }
            else
            {
                response.Mensaje = "¡Impacto directo! Mantienes el turno.";
            }

            await _partidaRepo.UpdateAsync(partida);
            await _unitOfWork.SaveChangesAsync();

            return Result<AtaqueResponseDto>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<AtaqueResponseDto>.Failure($"Error al procesar el disparo: {ex.Message}");
        }
    }

    public async Task<Result<bool>> RendirseAsync(int partidaId, string jugadorQueSeRindeId)
    {
        var partida = await _partidaRepo.GetByIdAsync(partidaId);
        if (partida == null || partida.Estado != EstadoPartida.EnProgreso)
            return Result<bool>.Failure("Partida no encontrada o ya inactiva.");

        partida.Estado = EstadoPartida.Finalizada;
        partida.GanadorId = partida.Jugador1Id == jugadorQueSeRindeId ? partida.Jugador2Id : partida.Jugador1Id;
        partida.FechaFin = DateTime.UtcNow; 

        await _partidaRepo.UpdateAsync(partida);
        await _unitOfWork.SaveChangesAsync();

        return Result<bool>.Success(true);
    }
}