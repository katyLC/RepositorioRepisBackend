﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class PalabarasClavesRepositorio : IPalabrasClavesRepositorio
    {
        private readonly AppContext _appContext;

        public PalabarasClavesRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        public List<KeywordEntity> ListarPalabrasClaves()
        {
            List<KeywordEntity> palabrasClaves = (from c in _appContext.Keyword
                    select new KeywordEntity()
                    {
                        IdKeyword = c.IdKeyword,
                        KeywordDescripcion = c.KeywordDescripcion
                    }

                ).ToList();
            return palabrasClaves;
        }

        public async Task RegistrarKeyword(Keyword keyword) {
            await _appContext.Keyword.AddAsync(keyword);
            await _appContext.SaveChangesAsync();
        }
    }
}