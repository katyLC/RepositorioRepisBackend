using System.Collections;
using System.Collections.Generic;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IProyectoRepositorio
    {
        List<ListarProyectoDTO> ListarProyecto();

        void RegistrarProyecto(Proyecto proyecto);

        IList<Proyecto> detalleProyecto();
        
    }
}