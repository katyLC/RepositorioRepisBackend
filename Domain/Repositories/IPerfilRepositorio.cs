using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IPerfilRepositorio
    {
        List<PerfilEntity> Listar();
    }
}