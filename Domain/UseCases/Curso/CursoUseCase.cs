using System;
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

        public async Task<Data.DbModel.Curso> BuscarCursoPorId(int id) {
            return await _cursoRepositorio.BuscarCursoPorId(id);
        }

        public async Task<CursoResponse> ActualizarCurso(int id, Data.DbModel.Curso curso) {
            var cursoActual = await _cursoRepositorio.BuscarCursoPorId(id);
            if (cursoActual == null) {
                return new CursoResponse("No existe el curso.");
            }
            cursoActual.IdProfesor = curso.IdProfesor;

            try {
                _cursoRepositorio.ActualizarCurso(cursoActual);
                return new CursoResponse(cursoActual);
            }
            catch (Exception e) {
                return new CursoResponse($"Error actualizando el curso: {e.Message}");
            }
        }
    }
}