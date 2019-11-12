using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IProyectoRepositorio
    {
        List<ProyectoEntity> ListarProyecto();

        void RegistrarProyecto(ProyectoEntity proyecto);

        IList<ProyectoEntity> detalleProyecto();
    }
}