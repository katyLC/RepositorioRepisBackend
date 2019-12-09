using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio {
    public class ProyectoRepositortio : IProyectoRepositorio {
        private readonly AppContext _appContext;

        public ProyectoRepositortio(AppContext appContext) {
            _appContext = appContext;
        }

        public async Task<IEnumerable<ProyectoResource2>> ListarProyectos(int idEstado) {
            var proyectos = (from pr in _appContext.Proyecto
                join c in _appContext.Curso
                    on pr.IdCurso equals c.IdCurso
                join pe in _appContext.Perfil
                    on c.IdPerfil equals pe.IdPerfil
                join ci in _appContext.Ciclo on
                    c.IdCiclo equals ci.IdCiclo
                join p in _appContext.Paper on
                    pr.IdPaper equals p.IdPaper
                    join e in _appContext.Estado on
                        pr.IdEstado equals e.IdEstado
                        join a in _appContext.Alumno on
                            pr.IdAlumno equals a.IdAlumno
                where pr.IdEstado == idEstado
                    select new ProyectoResource2() {
                        IdProyecto = pr.IdProyecto,
                        ProyectoNombre = pr.ProyectoNombre,
                        ProyectoTema = pr.ProyectoTema,
                        ProyectoGithubUrl = pr.ProyectoGithubUrl,
                        ProyectoDocumentoUrl = pr.ProyectoDocumentoUrl,
                        ProyectoPortadaUrl = pr.ProyectoPortadaUrl,
                        IdEstado = pr.IdEstado,
                        CursoNombre = c.CursoNombre,
                        CicloDescripcion = ci.CicloDescripcion,
                        PaperIntroduccion = p.PaperIntroduccion,
                        PaperResumen = p.PaperResumen,
                        EstadoDescripcion = e.EstadoDescripcion,
                        IdPerfil = pe.IdPerfil,
                        AlumnoNombre = string.Format("{0} {1}", a.AlumnoNombre, a.AlumnoApellidos)
                    }
                ).ToListAsync();
            return await proyectos;
        }

        public async Task RegistrarProyecto(Proyecto proyecto) {
            await _appContext.Proyecto.AddAsync(proyecto);
            await _appContext.SaveChangesAsync();
        }

        public IList<ProyectoEntity> detalleProyecto() {
            throw new NotImplementedException();
        }

        public void ActualizarProyecto(Proyecto proyecto) {
            _appContext.Proyecto.Update(proyecto);
            _appContext.SaveChanges();
        }

        public async Task<Proyecto> BuscarProyectoPorId(int id) {
            return await _appContext.Proyecto
                .FindAsync(id);
        }

        public async Task<IEnumerable<Proyecto>> ObtenerProyectoPorAlumno(int id) {
            var proyectoAlumno = (from pr in _appContext.Proyecto
                    join c in _appContext.Curso
                        on pr.IdCurso equals c.IdCurso
                    join e in _appContext.Estado on pr.IdEstado equals
                        e.IdEstado
                    join pe in _appContext.Perfil
                        on c.IdPerfil equals pe.IdPerfil
                    join ci in _appContext.Ciclo on
                        c.IdCiclo equals ci.IdCiclo
                    join p in _appContext.Paper on
                        pr.IdPaper equals p.IdPaper
                    join a in _appContext.Alumno on
                        pr.IdAlumno equals a.IdAlumno
                    where a.IdAlumno == id
                    select new Proyecto {
                        IdProyecto = pr.IdProyecto,
                        ProyectoNombre = pr.ProyectoNombre,
                        ProyectoTema = pr.ProyectoTema,
                        ProyectoGithubUrl = pr.ProyectoGithubUrl,
                        ProyectoDocumentoUrl = pr.ProyectoDocumentoUrl,
                        ProyectoPortadaUrl = pr.ProyectoPortadaUrl,
                        IdEstado = pr.IdEstado,
                        Paper = new Paper {
                            IdPaper = p.IdPaper,
                            PaperResumen = p.PaperResumen,
                            PaperIntroduccion = p.PaperIntroduccion
                        },

                        Estado = new Estado() {
                            EstadoDescripcion = e.EstadoDescripcion
                        },
                        Curso = new Curso {
                            IdCurso = c.IdCurso,
                            CursoNombre = c.CursoNombre,
                            Ciclo = new Ciclo() {
                                IdCiclo = ci.IdCiclo,
                                CicloDescripcion = ci.CicloDescripcion
                            },

                            Perfil = new Perfil {
                                IdPerfil = pe.IdPerfil,
                                PerfilDescripcion = pe.PerfilDescripcion,
                                PerfilColor = pe.PerfilColor,
                            }
                        }
                    }
                ).ToListAsync();

            return await proyectoAlumno;
        }

        public async Task<IEnumerable<Proyecto>> ObtenerProyectoAdministrador() {
            var proyectosAdministrador = (from pr in _appContext.Proyecto
                    join c in _appContext.Curso
                        on pr.IdCurso equals c.IdCurso
                    join pe in _appContext.Perfil
                        on c.IdPerfil equals pe.IdPerfil
                    join ci in _appContext.Ciclo on
                        c.IdCiclo equals ci.IdCiclo
                    join p in _appContext.Paper on
                        pr.IdPaper equals p.IdPaper
                    join e in _appContext.Estado on pr.IdEstado equals
                        e.IdEstado
                    where e.IdEstado == 1
                    select new Proyecto {
                        IdProyecto = pr.IdProyecto,
                        ProyectoNombre = pr.ProyectoNombre,
                        ProyectoTema = pr.ProyectoTema,
                        ProyectoGithubUrl = pr.ProyectoGithubUrl,
                        ProyectoDocumentoUrl = pr.ProyectoDocumentoUrl,
                        ProyectoPortadaUrl = pr.ProyectoPortadaUrl,
                        IdEstado = pr.IdEstado,
                        Paper = new Paper {
                            IdPaper = p.IdPaper,
                            PaperResumen = p.PaperResumen,
                            PaperIntroduccion = p.PaperIntroduccion
                        },
                        Estado = new Estado() {
                            EstadoDescripcion = e.EstadoDescripcion
                        },
                        Curso = new Curso {
                            IdCurso = c.IdCurso,
                            CursoNombre = c.CursoNombre,
                            Ciclo = new Ciclo() {
                                IdCiclo = ci.IdCiclo,
                                CicloDescripcion = ci.CicloDescripcion
                            },

                            Perfil = new Perfil {
                                IdPerfil = pe.IdPerfil,
                                PerfilDescripcion = pe.PerfilDescripcion,
                                PerfilColor = pe.PerfilColor,
                            }
                        }
                    }
                ).ToListAsync();

            return await proyectosAdministrador;
        }
    }
}