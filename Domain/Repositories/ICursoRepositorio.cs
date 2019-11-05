using System.Collections.Generic;
using RespositorioREPIS.Data;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface ICursoRepositorio
    {
        List<CursoDTO> ListarCurso(int id);
    }
}