using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.UseCases.Curso;

namespace RespositorioREPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : Controller
    {
        private readonly ICurso _curso;

        // GET
        public CursoController(ICurso curso)
        {
            _curso = curso;
        }

        // GET: api/curso/5
        [HttpGet("{id}")]
        public IList<CursoDTO> ListarCurso(int id)
        {
            return _curso.ListarCurso(id);
        }
    }
}