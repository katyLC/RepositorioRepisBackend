using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Repositories {
    public interface IProyectoAutorRepositorio {
        Task RegistrarProyectoAutor(ProyectoAutor proyectoAutor);
    }
}