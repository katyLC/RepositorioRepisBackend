using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class ProyectoRepositortio : IProyectoRepositorio
    {
        private readonly AppContext _appContext;

        public ProyectoRepositortio(AppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<IEnumerable<Proyecto>> ListarProyectos()
        {
            var proyectos = (from pr in _appContext.Proyecto
                    join c in _appContext.Curso
                        on pr.IdCurso equals c.IdCurso
                    join pe in _appContext.Perfil
                        on c.IdPerfil equals pe.IdPerfil
                        join ci in _appContext.Ciclo on 
                            c.IdCiclo equals ci.IdCiclo
                    join p in _appContext.Paper on 
                            pr.IdPaper equals p.IdPaper
                    select new Proyecto
                    {
                        IdProyecto = pr.IdProyecto,
                        ProyectoNombre = pr.ProyectoNombre,
                        ProyectoTema = pr.ProyectoTema,
                        ProyectoGithubUrl = pr.ProyectoGithubUrl,
                        ProyectoDocumentoUrl = pr.ProyectoDocumentoUrl,
                        ProyectoPortadaUrl = pr.ProyectoPortadaUrl,
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

            return await proyectos;
        }

        public async Task RegistrarProyecto(Proyecto proyecto)
        {
            await _appContext.Proyecto.AddAsync(proyecto);
            await _appContext.SaveChangesAsync();
        }

        public IList<ProyectoEntity> detalleProyecto()
        {
            throw new NotImplementedException();
        }

        public void ActualizarProyecto(Proyecto proyecto)
        {
            _appContext.Proyecto.Update(proyecto);
            _appContext.SaveChanges();
        }

        public async Task<Proyecto> BuscarProyectoPorId(int id)
        {
            return await _appContext.Proyecto
                .FindAsync(id);
        }
    }
}