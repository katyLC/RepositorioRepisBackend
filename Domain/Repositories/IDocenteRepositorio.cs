using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.UseCases.Docente;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IDocenteRepositorio {
        Task<IEnumerable<Profesor>> ListarProfesores();
        Task RegistrarDocente(Profesor profesor);
    }
    
    
}