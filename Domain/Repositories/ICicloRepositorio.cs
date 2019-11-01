using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface ICicloRepositorio
    {
        IList<Ciclo> Listar ();
    }
}