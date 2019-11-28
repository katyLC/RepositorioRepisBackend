using AutoMapper;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;

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
        }
    }
}