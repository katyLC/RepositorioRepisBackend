using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IDescargasRepositorio
    {
        Task RegistrarDescarga(Descarga descarga);
    }
}