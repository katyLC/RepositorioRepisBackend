using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.UseCases.Ciclo
{
    public interface ICicloUseCase
    {
        IList<CicloEntity> Listar();
    }
}