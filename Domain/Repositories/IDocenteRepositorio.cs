using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.UseCases.Docente;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IDocenteRepositorio
    {
        Task RegistrarDocente(Profesor profesor);
    }
    
    
}