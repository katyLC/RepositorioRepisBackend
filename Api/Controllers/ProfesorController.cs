using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Responses;
using RespositorioREPIS.Domain.UseCases.Curso;
using RespositorioREPIS.Domain.UseCases.Docente;

namespace RespositorioREPIS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : Controller
    
    {
        private readonly IDocenteUseCase _docenteUseCase;
        private readonly ICursoUseCase _cursoUseCase;
        private readonly IMapper _mapper;
        private List<Curso> _cursos = new List<Curso>();
        public ProfesorController(IDocenteUseCase docenteUseCase, ICursoUseCase cursoUseCase, IMapper mapper)
        {
            _docenteUseCase = docenteUseCase;
            _cursoUseCase = cursoUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProfesorResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> RegistrarDocente([FromBody] Data data) {
            if (data.Profesor != null) {
                MappidData(data);
                var profesor = _mapper.Map<ProfesorResource, Profesor>(data.Profesor);
                var resultProfesor = await _docenteUseCase.RegistrarDocente(profesor);

                if (!resultProfesor.Success) {
                    return BadRequest(new ErrorResource(resultProfesor.Message));
                }
                else {
                    if (_cursos != null) {
                        foreach (var curso in _cursos) {
                            curso.IdProfesor = resultProfesor.Resource.IdProfesor;
                            var result = await _cursoUseCase.ActualizarCurso(curso.IdCurso, curso);
                            if (!result.Success) {
                                return BadRequest(new ErrorResource(result.Message));
                            }
                        }
                    }
                }
            }

            return Ok("Guardado");
        }

        private void MappidData(Data data) {

            if (data.Cursos.Count == 0) return;
            foreach (var cursoResource in data.Cursos) {
                _cursos.Add(_mapper.Map<CursoResource, Curso>(cursoResource));
            }

        }
        public class Data {
            public ProfesorResource Profesor { get; set; }
            public List<CursoResource> Cursos { get; set; }
        }
    }
}