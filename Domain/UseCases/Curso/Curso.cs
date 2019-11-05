using System.Collections.Generic;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.UseCases.Curso
{
    public class Curso : ICurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public Curso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }
        
        public IList<CursoDTO> ListarCurso(int id)
        {
            return _cursoRepositorio.ListarCurso(id);
        }
    }
}