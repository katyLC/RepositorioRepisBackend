using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Responses;
using RespositorioREPIS.Domain.UseCases.Descargas;

namespace RespositorioREPIS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescargasController : Controller
    {
        private readonly IDescargaUseCase _descargaUseCase;
        private readonly IMapper _mapper;

       public DescargasController(IDescargaUseCase descargaUseCase, IMapper mapper)
        {
            _descargaUseCase = descargaUseCase;
            _mapper = mapper;
        }  
       
        [HttpPost]
        public async Task<IActionResult> RegistroDescarga([FromBody] DescargaResource resource)
        {
            var descarga = _mapper.Map<DescargaResource, Descarga>(resource);
             DescargasResponses result = await _descargaUseCase.RegistrarDescarga(descarga);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            var descargass = _mapper.Map<Descarga, DescargaResource>(result.Resource);
            return Ok( new{mensaje ="Guardado", descargass} );
        }
    }
}