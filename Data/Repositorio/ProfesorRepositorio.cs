using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class ProfesorRepositorio :IDocenteRepositorio

    {
        private readonly AppContext _appContext;
        private IDocenteRepositorio _docenteRepositorioImplementation;

        public ProfesorRepositorio(AppContext appContext)
        {
            _appContext =appContext;
        }
        public void RegistrarDocente(Profesor profesor)
        {
            _appContext.Profesor.Add(Profesor.FromProfesor(profesor));
            _appContext.SaveChanges();
        }
    }
}

