using RespositorioREPIS.Domain.Repositories;
 

namespace RespositorioREPIS.Domain.UseCases.Alumno
{
    public class RegistrarAlumno : IRegistrarAlumno
    {
        private readonly IAlumnoRepositorio _alumnoRepositorio;

        public RegistrarAlumno(IAlumnoRepositorio alumnoRepositorio)
        {
            _alumnoRepositorio = alumnoRepositorio;
        }

        public void Registrar(string alumnoNombre, string alummoApellidos,
            string alumnoCodigoUniversitario,
            int idCiclo)

        {
            
            _alumnoRepositorio.Create(new Entities.AlumnoRepositorio( alumnoNombre, alummoApellidos, alumnoCodigoUniversitario, idCiclo));
        }
    }
}