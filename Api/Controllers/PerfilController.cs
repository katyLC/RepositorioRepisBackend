using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.UseCases.Perfil;

namespace RespositorioREPIS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PerfilController : Controller
    {
        // GET
        private readonly IPerfilUseCase _perfilUseCase;

        public PerfilController(IPerfilUseCase perfilUseCase)
        {
            _perfilUseCase = perfilUseCase;
        }

        [HttpGet]
        public IList<PerfilEntity> Listar()
        {
            return _perfilUseCase.Listar();
        }
    }
}