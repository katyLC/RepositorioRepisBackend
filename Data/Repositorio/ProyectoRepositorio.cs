using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<ProyectoEntity> ListarProyecto()
        {
            var proyectos = (from pr in _appContext.Proyecto
                    join c in _appContext.Curso
                        on pr.IdCurso equals c.IdCurso
                    join pe in _appContext.Perfil
                        on c.IdPerfil equals pe.IdPerfil
                    select new ProyectoEntity
                    {
                        IdProyecto = pr.IdProyecto,
                        ProyectoNombre = pr.ProyectoNombre,
                        Curso = new CursoEntity
                        {
                            IdCurso = c.IdCurso,
                            CursoNombre = c.CursoNombre,
                            Perfil = new PerfilEntity
                            {
                                IdPerfil = pe.IdPerfil,
                                PerfilDescripcion = pe.PerfilDescripcion,
                                PerfilColor = pe.PerfilColor
                            }
                        }
                    }
                ).ToList();

            return proyectos;
        }

        public void RegistrarProyecto(ProyectoEntity proyecto)
        {
            _appContext.Proyecto.Add(Proyecto.FromProyecto(proyecto));
            _appContext.SaveChanges();
        }

        public IList<ProyectoEntity> detalleProyecto()
        {
            throw new NotImplementedException();
        }
    }
}