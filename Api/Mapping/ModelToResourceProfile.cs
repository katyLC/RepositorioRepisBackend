using AutoMapper;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Api.Resources.Keyword;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Proyecto, ProyectoResource>();
            CreateMap<ProyectoKeyword, ProyectoKeywordResource>();
            CreateMap<Paper, PaperResource>();
            CreateMap<Alumno, AlumnoResource>();
            CreateMap<Usuario, UsuarioResource>();
            CreateMap<Keyword, KeywordResource>();
            CreateMap<Curso, CursoResource>();
            CreateMap<Profesor, ProfesorResponse>();
            CreateMap<Descarga, DescargaResource>();
        }
    }
}