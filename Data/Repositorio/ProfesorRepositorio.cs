using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class ProfesorRepositorio :IDocenteRepositorio

    {
        private readonly AppContext _appContext;

        public ProfesorRepositorio(AppContext appContext)
        {
            _appContext =appContext;
        }
        public async Task RegistrarDocente(Profesor profesor)
        {
            _appContext.Profesor.Add(profesor);
            _appContext.SaveChanges();
        }
    }
}

