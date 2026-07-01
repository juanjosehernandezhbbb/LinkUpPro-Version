using LinkUp.Core.Application.Interfaces.Services;
using LinkUp.Core.Application.DTOs.Posts;
using LinkUp.Core.Domain.Entities;
using LinkUp.Core.Domain.Interfaces;
using AutoMapper;

namespace LinkUp.Core.Application.Services;

public class ComentarioService : IComentarioService
{
    private readonly IGenericRepository<Comentario> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ComentarioService(IGenericRepository<Comentario> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<ComentarioDto>> GetComentariosPorPublicacionAsync(int publicacionId)
    {
        var todos = await _repository.GetAllAsync();
        var comentarios = todos.Where(c => c.PublicacionId == publicacionId && !c.IsDeleted).ToList();

        return _mapper.Map<List<ComentarioDto>>(comentarios);
    }

    public async Task<ComentarioDto> CreateCommentAsync(ComentarioDto dto)
    {
        var comentario = _mapper.Map<Comentario>(dto);

        await _repository.AddAsync(comentario);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<ComentarioDto>(comentario);
    }

    public async Task DeleteCommentAsync(int commentId, string usuarioId)
    {
        var comentario = await _repository.GetByIdAsync(commentId);

        if (comentario != null && comentario.AutorId == usuarioId)
        {
            comentario.IsDeleted = true; 
            await _repository.UpdateAsync(comentario);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}