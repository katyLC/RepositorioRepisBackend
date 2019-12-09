using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly AppContext _appContext;

        public CursoRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }

        public List<CursoEntity> ListarCurso(int id)
        {
            List<CursoEntity> cursos = (from c in _appContext.Curso
                    join p in _appContext.Perfil
                        on c.IdPerfil equals p.IdPerfil
                    where c.IdCiclo == id
                    select new CursoEntity()
                    {
                        IdCurso = c.IdCurso,
                        CursoNombre = c.CursoNombre,
                        Perfil = new PerfilEntity()
                        {
                            IdPerfil = p.IdPerfil,
                            PerfilDescripcion = p.PerfilDescripcion,
                            PerfilColor = p.PerfilColor
                        }
                    }
                ).ToList();
            return cursos;
        }

        public async Task<IEnumerable<CursosEntity>> ListarCursos()
        {
            var cursosEntities = (from c in _appContext.Curso
                    join pro in _appContext.Profesor on c.IdProfesor equals pro.IdProfesor
                    where c.IdProfesor == 0
                    select new CursosEntity()
                    {
                        IdCurso = c.IdCurso,
                        CursoNombre = c.CursoNombre,
                        Profesor = new Profesor()
                        {
                            IdProfesor = pro.IdProfesor
                        }
                    }
                ).ToList();
            return  cursosEntities;
        }

        public async Task<Curso> BuscarCursoPorId(int id) {
            return await _appContext.Curso.FindAsync(id);
        }

        public void ActualizarCurso(Curso curso) {
            _appContext.Curso.Update(curso);
            _appContext.SaveChanges();
        }
    }
}