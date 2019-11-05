using System.Collections.Generic;
using RespositorioREPIS.Data;

namespace RespositorioREPIS.Domain.UseCases.Ciclo
{
    public interface ICicloListar
    {
       IList<CicloDTO> Listar();

    }
}