using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.UseCases.Docente;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IDocenteRepositorio
    {
        void RegistrarDocente(Profesor profesor);
    }
    
    
}