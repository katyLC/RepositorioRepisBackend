using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Domain.UseCases.Docente;

namespace RespositorioREPIS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : Controller
    
    {
        
        private readonly IDocenteUseCase _docenteUseCase;

        public ProfesorController(IDocenteUseCase docenteUseCase)
        {
            _docenteUseCase = docenteUseCase;
        }

        [HttpPost]
        public void RegistrarDocente([FromBody] ProfesorComand profesor)
        {
            _docenteUseCase.RegistrarDocente( profesor.ProfesorNombre, profesor.ProfesorApellido,profesor.ProfesorEmail);
        }

        // GET
        /*public IActionResult Index()
        {
            return View();
        }*/
        public class ProfesorComand
        {
            public string ProfesorNombre { get; set; }
            public string ProfesorApellido { get; set; }
            public string ProfesorEmail { get; set; }
        }
    }
}