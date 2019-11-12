using System.Collections.Generic;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

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
    }
}