using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class AlumnoRepositorio : IAlumnoRepositorio
    {
        private readonly AppContext _appContext;

        public AlumnoRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Create(AlumnoEntity alumno)
        {
            _appContext.Alumno.Add(Alumno.FromAlumno(alumno));

            _appContext.SaveChanges();
        }
    }
}