using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Api.Resources.Keyword;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Responses;
using RespositorioREPIS.Domain.UseCases.Autor;
using RespositorioREPIS.Domain.UseCases.PalabrasClaves;
using RespositorioREPIS.Domain.UseCases.Paper;
using RespositorioREPIS.Domain.UseCases.Proyecto;
using RespositorioREPIS.Domain.UseCases.ProyectoAutor;
using RespositorioREPIS.Domain.UseCases.ProyectoKeyword;

namespace RespositorioREPIS.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : Controller {
        private readonly IProyectoKeywordUseCase _proyectoKeywordUseCase;
        private readonly IPalabrasClavesUseCase _palabrasClavesUseCase;
        private readonly IProyectoAutorUseCase _proyectoAutorUseCase;
        private readonly IAutorUseCase _autorUseCase;
        private readonly IProyectoUseCase _proyectoUseCase;
        private readonly IPaperUseCase _paperUseCase;
        private readonly IMapper _mapper;
        private Proyecto _proyecto;
        private Paper _paper;
        private List<ProyectoKeyword> _proyectoKeywords = new List<ProyectoKeyword>();
        private List<ProyectoAutor> _proyectoAutores = new List<ProyectoAutor>();
        private List<Keyword> _keywords = new List<Keyword>();
        private List<Autor> _autores = new List<Autor>();

        public ProyectoController(IProyectoUseCase proyectoUseCase, IPaperUseCase paperUseCase, IAutorUseCase autorUseCase,
            IProyectoKeywordUseCase proyectoKeywordUseCase, IPalabrasClavesUseCase palabrasClavesUseCase,
            IProyectoAutorUseCase proyectoAutorUseCase,
            IMapper mapper) {
            _proyectoKeywordUseCase = proyectoKeywordUseCase;
            _palabrasClavesUseCase = palabrasClavesUseCase;
            _proyectoAutorUseCase = proyectoAutorUseCase;
            _proyectoUseCase = proyectoUseCase;
            _paperUseCase = paperUseCase;
            _autorUseCase = autorUseCase;
            _mapper = mapper;
        }

        // GET
        [HttpGet]
        public async Task<IEnumerable<ProyectoResource>> ListarProyecto() {
            var proyectos = await _proyectoUseCase.ListarProyectos();
            var resources = _mapper.Map<IEnumerable<Proyecto>, IEnumerable<ProyectoResource>>(proyectos);

            return resources;
        }


        [HttpGet("proyectos/admin")]
        public async Task<IEnumerable<ProyectoResource>> ObtenerProyectoAdministrador()
        {

            var proyectosAdministrador = await _proyectoUseCase.ObtenerProyectoAdmintrador();
            var resources = _mapper.Map<IEnumerable<Proyecto>, IEnumerable<ProyectoResource>>(proyectosAdministrador);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<ProyectoResource> ObtenerProyectoId(int id) {
            var proyecto = await _proyectoUseCase.BuscarProyectoPorId(id);
            var resource = _mapper.Map<Proyecto, ProyectoResource>(proyecto);
            return resource;
        }
        [HttpGet("proyectos/{id}")]
        public async Task<IEnumerable<ProyectoResource>> ObtenerProyectoPorAlumno(int id)
        {
            var proyectoPorAlumno = await _proyectoUseCase.ObtenerProyectoPorAlumno(id);
            var resource =  _mapper.Map<IEnumerable<Proyecto>, IEnumerable<ProyectoResource>>(proyectoPorAlumno);
            return resource;
        }
        
        
        [HttpPut("actualizar")]
        public async Task<IActionResult> ActualizarProyectoEstado([FromBody] ActualizarProyectoEstado aaActualizarProyectoEstado)
        {
            var resultEstado = await _proyectoUseCase.ActualizarProyecto(aaActualizarProyectoEstado);


            if (!resultEstado.Success)
            {
                return BadRequest(new ErrorResource(resultEstado.Message));
            }
            return Ok(new { mensaje ="Actualizado"});
            
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(ProyectoResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> RegistrarProyecto([FromBody] Data data) {
            if (data.Proyecto != null && data.Paper != null) {
                MappingData(data);

                PaperResponse resultPaper = await _paperUseCase.RegistrarPaper(_paper);

                if (!resultPaper.Success) {
                    return BadRequest(new ErrorResource(resultPaper.Message));
                }
                else {
                    _proyecto.IdPaper = resultPaper.Resource.IdPaper;
                    ProyectoResponse resultProyecto = await _proyectoUseCase.RegistrarProyecto(_proyecto);

                    if (!resultProyecto.Success) {
                        return BadRequest(new ErrorResource(resultProyecto.Message));
                    }
                    else
                    {

                        GuardarDocumento(data.Proyecto, data.Doc);
                        
                        if (data.Keywords != null) {
                            foreach (var keyword in _keywords) {
                                var result = await _palabrasClavesUseCase.RegistrarKeyword(keyword);
                                if (!result.Success) {
                                    return BadRequest(new ErrorResource(result.Message));
                                }

                                _proyectoKeywords.Add(new ProyectoKeyword {
                                    IdKeyword = result.Resource.IdKeyword
                                });
                            }
                        }

                        foreach (var proyectoKeyword in _proyectoKeywords) {
                            proyectoKeyword.IdProyecto = resultProyecto.Resource.IdProyecto;
                            var result = await _proyectoKeywordUseCase.RegistrarProyectoKeyword(proyectoKeyword);
                            if (!result.Success) {
                                return BadRequest(new ErrorResource(result.Message));
                            }
                        }

                        if (data.Autores.Count != 0) {
                            foreach (var autor in _autores) {
                                var result = await _autorUseCase.RegistrarAutor(autor);
                                if (!result.Success) {
                                    return BadRequest(new ErrorResource(result.Message));
                                }
                                _proyectoAutores.Add(new ProyectoAutor {
                                    IdAutor = result.Resource.IdAutor
                                });
                            }
                        }

                        foreach (var proyectoAutor in _proyectoAutores) {
                            proyectoAutor.IdProyecto = resultProyecto.Resource.IdProyecto;
                            var result = await _proyectoAutorUseCase.RegistrarProyectoAutor(proyectoAutor);
                            if (!result.Success) {
                                return BadRequest(new ErrorResource(result.Message));
                            }
                        }

                        return Ok(new {mensaje = "Guardado."});
                    }
                }
            }
            else {
                BadRequest(new ErrorResource("Faltan datos."));
            }

            return Ok();
        }

        private void GuardarDocumento(GuardarProyectoResource dataProyecto, string dataDoc)
        {
            string name = dataProyecto.ProyectoDocumentoUrl;
            var image = dataDoc;
            if (image != null) {
                
                var imageDataByteArray = Convert.FromBase64String(image);

                var imageDataStream = new MemoryStream(imageDataByteArray);
                imageDataStream.Position = 0;

                var filePath = Path.Combine("wwwroot/docs", name);
                using (FileStream file = new FileStream(filePath, FileMode.Create, System.IO.FileAccess.Write)) {
                    byte[] bytes = new byte[imageDataStream.Length];
                    imageDataStream.Read(bytes, 0, (int)imageDataStream.Length);
                    file.Write(bytes, 0, bytes.Length);
                    imageDataStream.Close();
                }
            }
        }

        private void MappingData(Data data) {
            _proyecto = _mapper.Map<GuardarProyectoResource, Proyecto>(data.Proyecto);
            _paper = _mapper.Map<PaperResource, Paper>(data.Paper);

            if (data.Keywords.Count == 0) return;
            foreach (var keywordResource in data.Keywords) {
                _keywords.Add(_mapper.Map<GuardarKeywordResource, Keyword>(keywordResource));
            }

//            if (data.ProyectoKeywords.Count == 0) return;
//            foreach (var proyectoKeywordResource in data.ProyectoKeywords) {
//                _proyectoKeywords.Add(
//                    _mapper.Map<GuardarProyectoKeywordResource, ProyectoKeyword>(proyectoKeywordResource));
//            }

            if (data.Autores.Count == 0) return;
            foreach (var autorResource in data.Autores) {
                _autores.Add(_mapper.Map<GuardarAutorResource, Autor>(autorResource));
            }
        }
    }

    public class Data {
        
        public ActualizarProyectoEstado ProyectoEstado { get; set; }
        public GuardarProyectoResource Proyecto { get; set; }
        public PaperResource Paper { get; set; }
        public List<GuardarProyectoKeywordResource> ProyectoKeywords { get; set; }
        public List<GuardarKeywordResource> Keywords { get; set; }
        public List<GuardarAutorResource> Autores { get; set; }
        public string Doc { get; set; }
    }
}