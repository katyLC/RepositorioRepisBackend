using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RespositorioREPIS.Api.Resources;
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

        public async Task<IEnumerable<Profesor>> ListarProfesores() {
            var profesores = _appContext.Profesor.ToListAsync();
            return await profesores;

        }

        public async Task RegistrarDocente(Profesor profesor)
        {
            _appContext.Profesor.Add(profesor);
            _appContext.SaveChanges();
        }
    }
}

