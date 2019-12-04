using System.Threading.Tasks;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Descargas {
    public interface IDescargaUseCase {

        Task<DescargasResponses> RegistrarDescarga(Data.DbModel.Descargas descargas);


    }
}