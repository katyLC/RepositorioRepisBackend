using System.Collections;
using System.Collections.Generic;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.UseCases.PalabrasClaves
{
    public interface IPalabrasClaves
    {
        IList<KeywordEntity> ListarPalabrasClaves();
        
    }
}