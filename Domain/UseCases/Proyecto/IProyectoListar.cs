using System.Collections;
using System.Collections.Generic;

namespace RespositorioREPIS.Domain.UseCases.Proyecto
{
    public interface IProyectoListar
    {
        IList<Entities.Proyecto> ListarProyecto();
    }
}