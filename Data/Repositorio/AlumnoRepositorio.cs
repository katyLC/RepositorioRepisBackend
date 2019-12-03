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

        public async Task<IEnumerable<Proyecto>> ObtenerProyectoID(int id)
        {
            var proyectoAlumno = (from pr in _appContext.Proyecto
                    join c in _appContext.Curso
                        on pr.IdCurso equals c.IdCurso
                    join pe in _appContext.Perfil
                        on c.IdPerfil equals pe.IdPerfil
                        join ci in _appContext.Ciclo on 
                            c.IdCiclo equals ci.IdCiclo
                    join p in _appContext.Paper on 
                            pr.IdPaper equals p.IdPaper
                            join a in _appContext.Alumno on 
                                pr.IdAlumno equals a.IdAlumno
                               where a.IdAlumno ==id
                                
                    select new Proyecto
                    {
                        IdProyecto = pr.IdProyecto,
                        ProyectoNombre = pr.ProyectoNombre,
                        ProyectoTema = pr.ProyectoTema,
                        ProyectoGithubUrl = pr.ProyectoGithubUrl,
                        ProyectoDocumentoUrl = pr.ProyectoDocumentoUrl,
                        ProyectoPortadaUrl = pr.ProyectoPortadaUrl,
                        IdEstado = pr.IdEstado,
                        Paper = new Paper
                        {
                            IdPaper = p.IdPaper,
                            PaperResumen = p.PaperResumen,
                            PaperIntroduccion = p.PaperIntroduccion
                        },
                        Curso = new Curso
                        {
                            IdCurso = c.IdCurso,
                            CursoNombre = c.CursoNombre,
                            Ciclo = new Ciclo()
                            {
                                IdCiclo = ci.IdCiclo,
                               CicloDescripcion = ci.CicloDescripcion
                            },

                            Perfil = new Perfil
                            {
                                IdPerfil = pe.IdPerfil,
                                PerfilDescripcion = pe.PerfilDescripcion,
                                PerfilColor = pe.PerfilColor,
                                
                            }
                        
                        }
                    }
                ).ToListAsync();

            return await proyectoAlumno;
        }
    }
}