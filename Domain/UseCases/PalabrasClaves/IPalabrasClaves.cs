using System.Collections;
using System.Collections.Generic;
using RespositorioREPIS.Data;

namespace RespositorioREPIS.Domain.UseCases.PalabrasClaves
{
    public interface IPalabrasClaves
    {
        IList<PalabrasClavesDTO> ListarPalabrasClaves();
        
    }
}