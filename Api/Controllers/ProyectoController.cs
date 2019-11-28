using System.Collections.Generic;
using System.Resources;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Responses;
using RespositorioREPIS.Domain.UseCases.Paper;
using RespositorioREPIS.Domain.UseCases.Proyecto;
using RespositorioREPIS.Domain.UseCases.ProyectoKeyword;

namespace RespositorioREPIS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : Controller
    {
        private readonly IProyectoKeywordUseCase _proyectoKeywordUseCase;
        private readonly IProyectoUseCase _proyectoUseCase;
        private readonly IPaperUseCase _paperUseCase;
        private readonly IMapper _mapper;
        private Proyecto _proyecto;
        private Paper _paper;
        private List<ProyectoKeyword> _proyectoKeywords;

        public ProyectoController(IProyectoUseCase proyectoUseCase, IPaperUseCase paperUseCase,
            IProyectoKeywordUseCase proyectoKeywordUseCase, IMapper mapper)
        {
            _proyectoKeywordUseCase = proyectoKeywordUseCase;
            _proyectoUseCase = proyectoUseCase;
            _paperUseCase = paperUseCase;
            _mapper = mapper;
        }

        // GET
        [HttpGet]
        public async Task<IEnumerable<ProyectoResource>> ListarProyecto()
        {
            var proyectos = await _proyectoUseCase.ListarProyectos();
            var resources = _mapper.Map<IEnumerable<Proyecto>, IEnumerable<ProyectoResource>>(proyectos);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<ProyectoResource> ObtenerProyectoId(int id)
        {
            var proyecto = await _proyectoUseCase.BuscarProyectoPorId(id);
            var resource =  _mapper.Map<Proyecto, ProyectoResource>(proyecto);
            return resource;
        }
        
       
        [HttpPost]
        [ProducesResponseType(typeof(ProyectoResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> RegistrarProyecto([FromBody] Data data)
        {
            if (data.Proyecto != null && data.Paper != null &&
                data.ProyectoKeywords != null)
            {
                MappingData(data);

                PaperResponse resultPaper = await _paperUseCase.RegistrarPaper(_paper);

                if (!resultPaper.Success)
                {
                    return BadRequest(new ErrorResource(resultPaper.Message));
                }
                else
                {
                    _proyecto.IdPaper = resultPaper.Resource.IdPaper;
                    ProyectoResponse resultProyecto = await _proyectoUseCase.RegistrarProyecto(_proyecto);

                    if (!resultProyecto.Success)
                    {
                        return BadRequest(new ErrorResource(resultProyecto.Message));
                    }
                    else
                    {
                        foreach (var resource in data.ProyectoKeywords)
                        {
                            var proyectoKeyword =
                                _mapper.Map<GuardarProyectoKeywordResource, ProyectoKeyword>(resource);
                            proyectoKeyword.IdProyecto = resultProyecto.Resource.IdProyecto;
                            var result = await _proyectoKeywordUseCase.RegistrarProyectoKeyword(proyectoKeyword);

                            if (!result.Success)
                            {
                                return BadRequest(new ErrorResource(result.Message));
                            }
                        }

                        return Ok(new {mensaje = "Guardado."});
                    }
                }
            }
            else
            {
                BadRequest(new ErrorResource("Faltan datos."));
            }

            return Ok();
        }
        
        
        
        
        private void MappingData(Data data)
        {
            _proyecto = _mapper.Map<GuardarProyectoResource, Proyecto>(data.Proyecto);
            _paper = _mapper.Map<PaperResource, Paper>(data.Paper);
        }
    }

    public class Data
    {
        public GuardarProyectoResource Proyecto { get; set; }
        public PaperResource Paper { get; set; }
        public List<GuardarProyectoKeywordResource> ProyectoKeywords { get; set; }
    }
}