using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.UseCases.Curso;

namespace RespositorioREPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : Controller
    {
        private readonly ICursoUseCase _cursoUseCase;

        // GET
        public CursoController(ICursoUseCase cursoUseCase)
        {
            _cursoUseCase = cursoUseCase;
        }

        // GET: api/curso/5
        [HttpGet("{id}")]
        public IList<CursoEntity> ListarCurso(int id)
        {
            return _cursoUseCase.ListarCurso(id);
        }

    }
}