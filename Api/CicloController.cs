using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.UseCases.Ciclo;

namespace RespositorioREPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CicloController : Controller
    {
        private readonly ICicloListar _cicloListar;

        public CicloController(ICicloListar cicloListar)
        {
            _cicloListar = cicloListar;
        }

        [HttpGet]
        public IList<Ciclo> Listar()
        {
            return _cicloListar.Listar();
        }
    }
}
