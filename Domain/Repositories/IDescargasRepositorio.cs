using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IDescargasRepositorio
    {
        Task RegistrarDescarga(Descarga descarga);
        Task<IEnumerable<DescargaResource2>> ListarDescargas();
    }
}