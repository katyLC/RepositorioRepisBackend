using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.UseCases.ProyectoKeyword;

namespace RespositorioREPIS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoKeywordController : Controller
    {
        private readonly IProyectoKeywordUseCase _proyectoKeywordUseCase;
        private readonly IMapper _mapper;

        public ProyectoKeywordController(IProyectoKeywordUseCase proyectoKeywordUseCase, IMapper mapper)
        {
            _proyectoKeywordUseCase = proyectoKeywordUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProyectoKeywordResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> RegistrarProyectoKeyword(
            [FromBody] List<GuardarProyectoKeywordResource> resources)
        {
            var proyectoKeywordResources = new List<ProyectoKeywordResource>();
            foreach (var resource in resources)
            {
                var proyectoKeyword = _mapper.Map<GuardarProyectoKeywordResource, ProyectoKeyword>(resource);
                var result = await _proyectoKeywordUseCase.RegistrarProyectoKeyword(proyectoKeyword);

                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }

                proyectoKeywordResources.Add(_mapper.Map<ProyectoKeyword, ProyectoKeywordResource>(result.Resource));
            }

            return Ok(proyectoKeywordResources);
        }
    }
}