using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.UseCases.Ciclo;

namespace RespositorioREPIS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CicloController : Controller
    {
        private readonly ICicloUseCase _cicloUseCase;

        public CicloController(ICicloUseCase cicloUseCase)
        {
            _cicloUseCase = cicloUseCase;
        }

        [HttpGet]
        public IList<CicloEntity> Listar()
        {
            return _cicloUseCase.Listar();
        }
    }
}
