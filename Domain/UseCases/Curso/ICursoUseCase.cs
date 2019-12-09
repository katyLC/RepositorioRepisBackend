using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Curso
{
    public interface ICursoUseCase
    {
        IList<CursoEntity> ListarCurso(int id);
      Task<IEnumerable<CursosEntity>> ListarCursos();
      Task<Data.DbModel.Curso> BuscarCursoPorId(int id);
      Task<CursoResponse> ActualizarCurso(int id, Data.DbModel.Curso curso);

    }
}