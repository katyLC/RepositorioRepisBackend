using System.Collections.Generic;
using System.Linq;
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
    }
}