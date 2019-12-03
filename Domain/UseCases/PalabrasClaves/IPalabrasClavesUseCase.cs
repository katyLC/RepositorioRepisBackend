using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Data;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.PalabrasClaves
{
    public interface IPalabrasClavesUseCase
    {
        IList<KeywordEntity> ListarPalabrasClaves();
        Task<KeywordResponse> RegistrarKeyword(Keyword keyword);
    }
}