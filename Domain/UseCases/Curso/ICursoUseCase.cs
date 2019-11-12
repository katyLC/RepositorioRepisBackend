using System.Collections;
using System.Collections.Generic;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.UseCases.Curso
{
    public interface ICursoUseCase
    {
        IList<CursoEntity> ListarCurso(int id);
    }
}