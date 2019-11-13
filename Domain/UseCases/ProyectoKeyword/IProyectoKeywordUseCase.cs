using System.Threading.Tasks;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.ProyectoKeyword
{
    public interface IProyectoKeywordUseCase
    {
        Task<ProyectoKeywordResponse> RegistrarProyectoKeyword(Data.DbModel.ProyectoKeyword proyectoKeyword);
    }
}