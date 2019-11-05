using System.Collections;
using System.Collections.Generic;
using RespositorioREPIS.Data;

namespace RespositorioREPIS.Domain.UseCases.Curso
{
    public interface ICurso
    {
        IList<CursoDTO> ListarCurso(int id);
    }
}