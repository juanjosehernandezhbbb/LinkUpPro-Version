using LinkUp.Core.Application.Interfaces.Services;
using LinkUp.Core.Application.DTOs.Posts;
using LinkUp.Core.Application.Common;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Interfaces;
using AutoMapper;

namespace LinkUp.Core.Application.Services;

public class PublicacionService : IPublicacionService
{
    private readonly IGenericRepository<Publicacion> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PublicacionService(
        IGenericRepository<Publicacion> repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PublicacionDto>> GetByIdAsync(int id)
    {
        var publicacion = await _repository.GetByIdAsync(id);

        if (publicacion == null || publicacion.IsDeleted)
            return Result<PublicacionDto>.Failure("Publicación no encontrada.");

        var dto = _mapper.Map<PublicacionDto>(publicacion);
        return Result<PublicacionDto>.Success(dto);
    }

    public async Task<Result<IReadOnlyList<PublicacionDto>>> GetMuroUsuariosAsync(string usuarioActualId)
    {
        var todasLasPublicaciones = await _repository.GetAllAsync();
        var dtos = _mapper.Map<List<PublicacionDto>>(todasLasPublicaciones);

        return Result<IReadOnlyList<PublicacionDto>>.Success(dtos);
    }

    public async Task<Result<PublicacionDto>> CreateAsync(CrearPublicacionDto dto)
    {
        try
        {
            var publicacion = _mapper.Map<Publicacion>(dto);

            // Asignar el enlace multimedia dependiendo del tipo que escogió el usuario
            publicacion.ImagenUrl = dto.ImagenUrl ?? dto.VideoYouTubeUrl;

            await _repository.AddAsync(publicacion);
            await _unitOfWork.SaveChangesAsync();

            var publicacionGuardadaDto = _mapper.Map<PublicacionDto>(publicacion);
            return Result<PublicacionDto>.Success(publicacionGuardadaDto);
        }
        catch (Exception ex)
        {
            return Result<PublicacionDto>.Failure($"Error al crear la publicación: {ex.Message}");
        }
    }

    public async Task<Result<bool>> UpdateAsync(int id, CrearPublicacionDto dto, string usuarioId)
    {
        var publicacion = await _repository.GetByIdAsync(id);

        if (publicacion == null || publicacion.IsDeleted)
            return Result<bool>.Failure("Publicación no encontrada.");

        // GUARDARRAÍL DE SEGURIDAD: Solo el autor puede editarla
        if (publicacion.AutorId != usuarioId)
            return Result<bool>.Failure("No tienes permiso para editar esta publicación.");

        // Actualizamos los datos
        publicacion.Contenido = dto.Contenido;
        publicacion.Privacidad = dto.Privacidad;
        publicacion.TipoContenido = dto.TipoContenido;
        publicacion.ImagenUrl = dto.ImagenUrl ?? dto.VideoYouTubeUrl;

        await _repository.UpdateAsync(publicacion);
        await _unitOfWork.SaveChangesAsync();

        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteAsync(int id, string usuarioId)
    {
        var publicacion = await _repository.GetByIdAsync(id);

        if (publicacion == null || publicacion.IsDeleted)
            return Result<bool>.Failure("Publicación no encontrada.");

        // GUARDARRAÍL DE SEGURIDAD: Solo el autor puede eliminarla
        if (publicacion.AutorId != usuarioId)
            return Result<bool>.Failure("No tienes permiso para eliminar esta publicación.");

        // Borrado lógico para no romper la base de datos
        publicacion.IsDeleted = true;

        await _repository.UpdateAsync(publicacion);
        await _unitOfWork.SaveChangesAsync();

        return Result<bool>.Success(true);
    }
}