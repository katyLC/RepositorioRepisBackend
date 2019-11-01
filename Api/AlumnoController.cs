using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Domain.UseCases.Alumno;

namespace RespositorioREPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : Controller
    {
        private readonly IRegistrarAlumno _registrarAlumno;

        public AlumnoController(IRegistrarAlumno registrarAlumno)
        {
            _registrarAlumno = registrarAlumno;
        }
        
        public void RegistrarAlumno([FromBody] AlumnoComand comand)
        {
            _registrarAlumno.Registrar( comand.AlumnoNombre, comand.AlumnoApellidos, comand.AlumnoCodigoUniversitario, comand.IdCiclo);
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