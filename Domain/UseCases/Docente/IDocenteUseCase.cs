namespace RespositorioREPIS.Domain.UseCases.Docente
{
    public interface IDocenteUseCase
    {
        void RegistrarDocente(string profesorNombre, string profesorApellido, string profesorEmail);
    }
}