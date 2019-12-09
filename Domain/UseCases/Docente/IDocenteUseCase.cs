using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Docente
{
    public interface IDocenteUseCase
    {
        Task<ProfesorResponse> RegistrarDocente(Profesor profesor);
    }
}