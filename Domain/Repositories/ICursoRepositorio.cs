using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface ICursoRepositorio
    {
        List<CursoEntity> ListarCurso(int id);
    }
}