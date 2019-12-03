using System.Threading.Tasks;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.ProyectoAutor {
    public interface IProyectoAutorUseCase {
        Task<ProyectoAutorResponse> RegistrarProyectoAutor(Data.DbModel.ProyectoAutor proyectoAutor);
    }
}