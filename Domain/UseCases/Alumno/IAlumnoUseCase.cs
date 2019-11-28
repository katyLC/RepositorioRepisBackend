using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.UseCases.Alumno
{
    public interface IAlumnoUseCase
    {
        void Registrar(string alumnoNombre, string alummoApellidos, string alumnoCodigoUniversitario,
            int idCiclo);

      Task<Data.DbModel.Alumno> ObtenerAlumnoID(int id);


    }
}
