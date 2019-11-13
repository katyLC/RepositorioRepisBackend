using AutoMapper;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Api.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<GuardarProyectoResource, Proyecto>();
            CreateMap<GuardarProyectoKeywordResource, ProyectoKeyword>();
            CreateMap<PaperResource, Paper>();
        }
    }
}