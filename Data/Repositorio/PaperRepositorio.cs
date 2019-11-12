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

        public void RegistrarPaperRepositorio(PaperEntity paper)
        {
            _appContext.Paper.Add(Paper.FromPaper(paper));
            _appContext.SaveChanges();
        }
    }
}