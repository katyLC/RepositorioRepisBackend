using System.Collections.Generic;
using RespositorioREPIS.Data;
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
        
        public IList<PalabrasClavesDTO> ListarPalabrasClaves()
        {
            return _palabrasClavesRepositorio.ListarPalabrasClaves();
        }
    }
}