using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Repositories {
    public interface IAutorRepositorio {
        Task RegistrarAutor(Autor autor);
    }
}