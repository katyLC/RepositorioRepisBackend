using System.Collections.Generic;
using RespositorioREPIS.Data;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IPalabrasClavesRepositorio
    {
        List<PalabrasClavesDTO> ListarPalabrasClaves();
    }
}