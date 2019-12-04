using System.Threading.Tasks;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Autor {
    public interface IAutorUseCase {
        Task<AutorResponse> RegistrarAutor(Data.DbModel.Autor autor);
    }
}