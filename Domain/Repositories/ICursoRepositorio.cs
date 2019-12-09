using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface ICursoRepositorio
    {
        List<CursoEntity> ListarCurso(int id);
        Task<IEnumerable<CursosEntity>> ListarCursos();

        Task<Curso> BuscarCursoPorId(int id);
        void ActualizarCurso(Curso curso);
    }
}