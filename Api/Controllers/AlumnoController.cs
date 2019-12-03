using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.UseCases.Alumno;

namespace RespositorioREPIS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : Controller
    {
        private readonly IAlumnoUseCase _alumnoUseCase;
        private readonly IMapper _mapper;

        public AlumnoController(IAlumnoUseCase alumnoUseCase, IMapper mapper )
        {
            _alumnoUseCase = alumnoUseCase;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<AlumnoResource> ObtenerAlumnoID( int id)
        {
            var 
            alumno = await _alumnoUseCase.ObtenerAlumnoID(id);
            var resource = _mapper.Map<Alumno, AlumnoResource>(alumno);
            return resource;
        }
        
        public void RegistrarAlumno([FromBody] AlumnoComand alumno)
        {
            _alumnoUseCase.Registrar(alumno.AlumnoNombre, alumno.AlumnoApellidos, alumno.AlumnoCodigoUniversitario,
                alumno.IdCiclo);

        }
        


        public class AlumnoComand
        {
            public int IdAlumno { get; set; }
            public string AlumnoNombre { get; set; }
            public string AlumnoApellidos { get; set; }
            public string AlumnoCodigoUniversitario { get; set; }
            public int IdCiclo { get; set; }
        }
    }
}