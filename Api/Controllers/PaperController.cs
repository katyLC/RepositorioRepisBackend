using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Responses;
using RespositorioREPIS.Domain.UseCases.Paper;

namespace RespositorioREPIS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaperController : Controller
    {
        private readonly IPaperUseCase _paperUseCase;
        private readonly IMapper _mapper;

        public PaperController(IPaperUseCase paperUseCase, IMapper mapper)
        {
            _paperUseCase = paperUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaperResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> RegistrarPaper([FromBody] PaperResource resource)
        {
            var paper = _mapper.Map<PaperResource, Paper>(resource);
            PaperResponse result = await _paperUseCase.RegistrarPaper(paper);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var paperResource = _mapper.Map<Paper, PaperResource>(result.Resource);

            return Ok(new {mensaje = "Guardado satisfactoriamente", paperResource});
        }
    }
}