using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.UseCases.Ciclo;
using RespositorioREPIS.Domain.UseCases.Proyecto;

namespace RespositorioREPIS.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : Controller
    {
        private readonly IProyectoUseCase _proyectoUseCase;

        public ProyectoController(IProyectoUseCase proyectoUseCase)
        {
            _proyectoUseCase = proyectoUseCase;
        }

        // GET
        [HttpGet]
        public IList<ProyectoEntity> ListarProyecto()
        {
            return _proyectoUseCase.ListarProyecto();
        }

        [HttpPost]
        public void RegistrarProyecto([FromBody] ProyectoCommand proyecto)
        {
            _proyectoUseCase.RegistrarProyecto(proyecto.ProyectoNombre, proyecto.ProyectoTema,
                proyecto.ProyectoGithubUrl, proyecto.ProyectoDocumentoUrl, proyecto.ProyectoPortadaUrl,
                proyecto.IdCurso, proyecto.IdPaper, proyecto.IdEstado);
        }

        public class ProyectoCommand
        {
            public int IdProyecto { get; set; }
            public string ProyectoNombre { get; set; }
            public string ProyectoTema { get; set; }
            public string ProyectoGithubUrl { get; set; }
            public string ProyectoDocumentoUrl { get; set; }
            public string ProyectoPortadaUrl { get; set; }
            public int IdCurso { get; set; }
            public int IdPaper { get; set; }
            public int IdEstado { get; set; }
        }
    }
}