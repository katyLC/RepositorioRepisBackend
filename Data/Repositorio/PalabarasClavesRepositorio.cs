using System.Collections.Generic;
using System.Linq;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data
{
    public class PalabarasClavesRepositorio : IPalabrasClavesRepositorio
    {
        private readonly AppContext _appContext;

        public PalabarasClavesRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        public List<PalabrasClavesDTO> ListarPalabrasClaves()
        {
            List<PalabrasClavesDTO> palabrasClaves = (from c in _appContext.Keyword
                    select new PalabrasClavesDTO()
                    {
                        IdKeyword = c.IdKeyword,
                        KeywordDescripcion = c.KeywordDescripcion
                    }

                ).ToList();
            return palabrasClaves;
        }
    }
}