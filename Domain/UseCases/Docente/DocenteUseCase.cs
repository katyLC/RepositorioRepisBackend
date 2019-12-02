using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.UseCases.Docente

{
    public class DocenteUseCase : IDocenteUseCase
    {
        private readonly IDocenteRepositorio _docenteRepositorio;

        public DocenteUseCase(IDocenteRepositorio docenteRepositorio)
        {
            _docenteRepositorio = docenteRepositorio;
        }
        
        public void RegistrarDocente(string profesorNombre, string profesorApellido, string profesorEmail)
        {
           _docenteRepositorio.RegistrarDocente(new Profesor( profesorNombre, profesorApellido, profesorEmail)); 
            
        }
    }
}