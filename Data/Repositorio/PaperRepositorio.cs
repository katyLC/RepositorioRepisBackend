using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class PaperRepositorio : IPaperRepositorio
    {
        private readonly AppContext _appContext;

        public PaperRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task RegistrarPaperRepositorio(Paper paper)
        {
            await _appContext.Paper.AddAsync(paper);
            _appContext.SaveChanges();
        }
    }
}