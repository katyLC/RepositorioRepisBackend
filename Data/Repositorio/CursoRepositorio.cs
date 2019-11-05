using System.Collections.Generic;
using System.Linq;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data
{
    public class CursoRepositorio :ICursoRepositorio
    {


        private readonly AppContext _appContext;

        public CursoRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        public List<CursoDTO> ListarCurso(int id)
        {
            List<CursoDTO> cursos = (from c in _appContext.Curso join  p in _appContext.Perfil
                            on c.IdPerfil equals p.IdPerfil
                            where c.IdCiclo == id
                    select new CursoDTO()
                    {
                        IdCurso = c.IdCurso,
                        CursoNombre = c.CursoNombre,
                        PerfilNombre = p.PerfilDescripcion
                    }
                ).ToList();
            return cursos;
        }
    }
}