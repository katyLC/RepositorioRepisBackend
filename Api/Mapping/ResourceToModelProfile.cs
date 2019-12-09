using AutoMapper;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Api.Resources.Keyword;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Api.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<GuardarProyectoResource, Proyecto>();
            CreateMap<GuardarProyectoKeywordResource, ProyectoKeyword>();
            CreateMap<PaperResource, Paper>();
            CreateMap<AlumnoResource, Alumno>();
            CreateMap<UsuarioResource, Usuario>();
            CreateMap<GuardarKeywordResource, Keyword>();
            CreateMap<GuardarAutorResource, Autor>();
            CreateMap<CursoResource, Curso>();
            CreateMap<ProfesorResource, Profesor>();
        }
    }
}