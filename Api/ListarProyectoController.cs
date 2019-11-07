using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.UseCases.Ciclo;
using RespositorioREPIS.Domain.UseCases.Proyecto;

namespace RespositorioREPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListarProyectoController : Controller
    {
        private readonly IProyecto _proyecto;

        public ListarProyectoController(IProyecto proyecto)
        {
            _proyecto = proyecto;
        }

        // GET
        [HttpGet]
        public IList<ListarProyectoDTO> ListarProyecto()
        {
            return _proyecto.ListarProyecto();
        }
    }
}