namespace RespositorioREPIS.Domain.UseCases.Alumno
{
    public interface IRegistrarAlumno
    {
        void Registrar(string alumnoNombre, string alummoApellidos, string alumnoCodigoUniversitario,
            int idCiclo);

    }
}