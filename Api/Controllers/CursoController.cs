using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.UseCases.Curso;

namespace RespositorioREPIS.Api.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
    public class CursoController : Controller
    {
        private readonly ICursoUseCase _cursoUseCase;
        private readonly IMapper _mapper;

        // GET
        public CursoController(ICursoUseCase cursoUseCase, IMapper mapper)
        {
            _cursoUseCase = cursoUseCase;
            _mapper = mapper;
        }

        // GET: api/curso/5
        [HttpGet("{id}")]
        public IList<CursoEntity> ListarCurso(int id)
        {
            return _cursoUseCase.ListarCurso(id);
        }
        
        
        [HttpGet("cursos")]
        public async Task<IEnumerable<CursosEntity>> ListarCursos()
        {
            var ciclos = await _cursoUseCase.ListarCursos();
            return ciclos;
        }


    }
}