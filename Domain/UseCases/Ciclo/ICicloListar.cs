using System.Collections.Generic;

namespace RespositorioREPIS.Domain.UseCases.Ciclo
{
    public interface ICicloListar
    {
       IList<Entities.Ciclo> Listar();

    }
}