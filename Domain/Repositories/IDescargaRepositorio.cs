using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Repositories {
    public interface IDescargaRepositorio {
        Task RegistrarDescarga(Descargas descargas);
    }
}