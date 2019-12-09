using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Descargas
{
    public interface IDescargaUseCase
    {
        Task<DescargasResponses> RegistrarDescarga(Data.DbModel.Descarga descarga);
        Task<IEnumerable<DescargaResource2>> ListarDescargas();
    }
}