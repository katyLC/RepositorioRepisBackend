using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Data;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IPalabrasClavesRepositorio
    {
        List<KeywordEntity> ListarPalabrasClaves();
        Task RegistrarKeyword(Keyword keyword);
    }
}