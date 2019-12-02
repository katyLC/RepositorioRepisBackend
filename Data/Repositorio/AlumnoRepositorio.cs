using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class AlumnoRepositorio : IAlumnoRepositorio
    {
        private readonly AppContext _appContext;

        public AlumnoRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Create(AlumnoEntity alumno)
        {
            _appContext.Alumno.Add(Alumno.FromAlumno(alumno));
            _appContext.SaveChanges();
        }

        public async Task<Alumno> ObtenerAlumnID(int id)
        {
            var alumno = await (from a in _appContext.Alumno
                    join c in _appContext.Ciclo on a.IdCiclo equals c.IdCiclo
                    where a.IdAlumno == id
                    select new Alumno
                    {
                        IdAlumno = a.IdAlumno,
                        AlumnoNombre = a.AlumnoNombre,
                        AlumnoApellidos = a.AlumnoApellidos,
                        AlumnoCodigoUniversitario = a.AlumnoCodigoUniversitario,
                        Ciclo = new Ciclo
                        {
                            CicloDescripcion = c.CicloDescripcion
                        }
                    }
                ).FirstAsync();
            return alumno;
        }
    }
}