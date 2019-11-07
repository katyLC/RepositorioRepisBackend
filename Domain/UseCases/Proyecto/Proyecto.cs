using System.Collections.Generic;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.UseCases.Proyecto
{
    public class Proyecto : IProyecto
    {
        private readonly IProyectoRepositorio _proyectoRepositorio;

        public Proyecto(IProyectoRepositorio proyectoRepositorio)
        {
            _proyectoRepositorio = proyectoRepositorio;
        }

        public IList<ListarProyectoDTO> ListarProyecto()
        {
            return _proyectoRepositorio.ListarProyecto();
        }

        public void RegistrarProyecto(string proyectoNombre, string proyectoTema, string proyectoGithubURL,
            string proyectoDocumento, int idCurso)
        {
            _proyectoRepositorio.RegistrarProyecto(new Entities.Proyecto(proyectoNombre, proyectoTema,
                proyectoGithubURL, proyectoDocumento, idCurso));
        }

        public IList<Entities.Proyecto> detalleProyecto()
        {
            throw new System.NotImplementedException();
        }
    }
}