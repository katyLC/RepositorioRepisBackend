using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Api.Resources.Keyword;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Responses;
using RespositorioREPIS.Domain.UseCases.PalabrasClaves;

namespace RespositorioREPIS.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PalabrasClavesController : Controller
    {
        private readonly IPalabrasClavesUseCase _palabrasClavesUseCase;
        private readonly IMapper _mapper;

        public PalabrasClavesController(IPalabrasClavesUseCase palabrasClaves, IMapper mapper)
        {
            _palabrasClavesUseCase = palabrasClaves;
            _mapper = mapper;
        }

        [HttpGet]
        public IList<KeywordEntity> ListarPalabrasClaves()
        {
            return _palabrasClavesUseCase.ListarPalabrasClaves();
        }

        [HttpPost]
        [ProducesResponseType(typeof(KeywordResponse), 201)]
        [ProducesResponseType(typeof(KeywordResponse), 400)]
        public async Task<IActionResult> RegistrarKeyword([FromBody] List<GuardarKeywordResource> resources) {
            foreach (var resource in resources) {
                var keyword = _mapper.Map<GuardarKeywordResource, Keyword>(resource);
                var result = await _palabrasClavesUseCase.RegistrarKeyword(keyword);
                if (!result.Success) {
                    return BadRequest(new ErrorResource(result.Message));
                }
            }
            return Ok(new {mensaje = "Guardado satisfactoriamente"});
        }
    }
}