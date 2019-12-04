using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Curso
{
    public class CursoUseCaseUseCase : ICursoUseCase
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public CursoUseCaseUseCase(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }
        
        public IList<CursoEntity> ListarCurso(int id)
        {
            return _cursoRepositorio.ListarCurso(id);
        }

        public async Task<IEnumerable<CursosEntity>> ListarCursos()
        {
            return await _cursoRepositorio.ListarCursos();
        }

        public Task<CursoResponse> ActualizarCurso(int id, Data.DbModel.Curso curso)
        {
            throw new System.NotImplementedException();
        }
    }
}