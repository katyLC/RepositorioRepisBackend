using System.Collections.Generic;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.UseCases.PalabrasClaves
{
    public class PalabrasClaves : IPalabrasClaves
    {

        private readonly IPalabrasClavesRepositorio _palabrasClavesRepositorio;

        public PalabrasClaves(IPalabrasClavesRepositorio palabrasClavesRepositorio)
        {
            _palabrasClavesRepositorio = palabrasClavesRepositorio;
        }
        
        public IList<KeywordEntity> ListarPalabrasClaves()
        {
            return _palabrasClavesRepositorio.ListarPalabrasClaves();
        }
    }
}