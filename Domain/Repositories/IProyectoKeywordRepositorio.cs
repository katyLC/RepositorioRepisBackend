using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IProyectoKeywordRepositorio
    {
        Task RegistrarProyectoKeyword(ProyectoKeyword proyectoKeyword);
    }
}