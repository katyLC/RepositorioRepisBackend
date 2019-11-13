using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IPaperRepositorio
    {
        Task RegistrarPaperRepositorio(Paper paper);
    }
}