using System.Collections.Generic;
using System.Linq;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data
{
    public class CicloRepositorio : ICicloRepositorio
    {
        private readonly AppContext _appContext;

        public CicloRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }

        public List<CicloDTO> Listar()
        {
            List<CicloDTO> ciclos = (from c in _appContext.Ciclo
                    select new CicloDTO()
                    {
                        IdCiclo = c.IdCiclo,
                        CicloDescripcion = c.CicloDescripcion
                    }
                ).ToList();
            return ciclos;
        }
    }
}