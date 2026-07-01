using AutoMapper;
using LinkUp.Core.Application.DTOs.Friends;
using LinkUp.Core.Application.DTOs.Posts;
using LinkUp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Core.Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Publicacion, PublicacionDto>()
            .ForMember(dest => dest.NombreAutor, opt => opt.MapFrom(src => src.Autor.Nombre))
            .ForMember(dest => dest.ApellidoAutor, opt => opt.MapFrom(src => src.Autor.Apellido))
            .ForMember(dest => dest.FotoPerfilAutorUrl, opt => opt.MapFrom(src => src.Autor.FotoPerfilUrl));

        CreateMap<CrearPublicacionDto, Publicacion>();

        // Comentarios
        CreateMap<Comentario, ComentarioDto>()
            .ForMember(dest => dest.NombreAutor, opt => opt.MapFrom(src => src.Autor.Nombre))
            .ForMember(dest => dest.FotoPerfilAutorUrl, opt => opt.MapFrom(src => src.Autor.FotoPerfilUrl));
        CreateMap<CrearComentarioDto, Comentario>();

        // Solicitudes de Amistad
        CreateMap<SolicitudAmistad, SolicitudAmistadDto>()
            .ForMember(dest => dest.NombreEmisor, opt => opt.MapFrom(src => src.Emisor.Nombre))
            .ForMember(dest => dest.FotoEmisorUrl, opt => opt.MapFrom(src => src.Emisor.FotoPerfilUrl));
    }
}
