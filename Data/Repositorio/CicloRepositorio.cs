using System.Collections.Generic;
using System.Linq;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class CicloRepositorio : ICicloRepositorio
    {
        private readonly AppContext _appContext;

        public CicloRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }

        public List<CicloEntity> Listar()
        {
            var ciclos = (from c in _appContext.Ciclo
                    select new CicloEntity()
                    {
                        IdCiclo = c.IdCiclo,
                        CicloDescripcion = c.CicloDescripcion
                    }
                ).ToList();
            return ciclos;
        }
    }
}