using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class DescargasRepositorio : IDescargasRepositorio
    {

        private readonly AppContext _appContext;

        public DescargasRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        public async Task RegistrarDescarga(Descarga descarga)
        {
            await _appContext.Descargas.AddAsync(descarga);
            _appContext.SaveChanges();
        }
    }
}