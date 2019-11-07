using System.Collections.Generic;
using System.Linq;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data
{
    public class ProyectoRepositortio : IProyectoRepositorio
    {
        private readonly AppContext _appContext;

        public ProyectoRepositortio(AppContext appContext)
        {
            _appContext = appContext;
        }

        public List<ListarProyectoDTO> ListarProyecto()
        {
            List<ListarProyectoDTO> proyectos = (from pr in _appContext.Proyecto
                    join c in _appContext.Curso
                        on pr.IdCurso equals c.IdCurso
                    join pe in _appContext.Perfil
                        on c.IdPerfil equals pe.IdPerfil
                    select new ListarProyectoDTO()
                    {
                        IdProyecto = pr.IdProyecto,
                        ProyectoNombre = pr.ProyectoNombre,
                        IdPerfil = pe.IdPerfil
                    }
                ).ToList();
            return proyectos;
        }

        public void RegistrarProyecto(Proyecto proyecto)
        {
        }

        public IList<Proyecto> detalleProyecto()
        {
            throw new System.NotImplementedException();
        }
    }
}