using System.Collections;
using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IProyectoListarRepositorio
    {
        IList<Proyecto> ListarProyecto();
    }
}