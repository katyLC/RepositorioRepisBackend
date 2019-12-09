using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class DescargasRepositorio : IDescargasRepositorio
    {

        private readonly AppContext _appContext;

        public DescargasRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        public async Task RegistrarDescarga(Descarga descarga)
        {
            await _appContext.Descargas.AddAsync(descarga);
            _appContext.SaveChanges();
        }

        public async Task<IEnumerable<DescargaResource2>> ListarDescargas() {
            var proyectos = (from pr in _appContext.Proyecto
                join d in _appContext.Descargas on pr.IdProyecto equals d.IdProyecto
                join a in _appContext.Alumno on d.IdAlumno equals a.IdAlumno
                select new DescargaResource2() {
                    IdProyecto = pr.IdProyecto,
                    ProyectoNombre = pr.ProyectoNombre,
                    AlumnoNombre = string.Format("{0} {1}", a.AlumnoNombre, a.AlumnoApellidos)
                }).ToListAsync();
            return await proyectos;
        }
    }
}