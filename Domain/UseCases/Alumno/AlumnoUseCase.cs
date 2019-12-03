using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;


namespace RespositorioREPIS.Domain.UseCases.Alumno
{
    public class AlumnoUseCase : IAlumnoUseCase
    {
        private readonly IAlumnoRepositorio _alumnoRepositorio;

        public AlumnoUseCase(IAlumnoRepositorio alumnoRepositorio)
        {
            _alumnoRepositorio = alumnoRepositorio;
        }

        public void Registrar(string alumnoNombre, string alummoApellidos,
            string alumnoCodigoUniversitario,
            int idCiclo)
        {
            _alumnoRepositorio.Create(new AlumnoEntity(alumnoNombre, alummoApellidos, alumnoCodigoUniversitario,
                idCiclo));
        }

        public async Task<Data.DbModel.Alumno> ObtenerAlumnoID(int id) {
            return await _alumnoRepositorio.ObtenerAlumnID(id);
        }
        
        

//      
    }
}