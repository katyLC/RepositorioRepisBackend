using System.Collections;
using System.Collections.Generic;
using RespositorioREPIS.Data;

namespace RespositorioREPIS.Domain.UseCases.Proyecto
{
    public interface IProyecto
    {
        IList<ListarProyectoDTO> ListarProyecto();

        void RegistrarProyecto(string proyectoNombre, string proyectoTema, string proyectoGithubURL,
            string proyectoDocumento, int idCurso);


        IList<Entities.Proyecto> detalleProyecto();
        

    }
}