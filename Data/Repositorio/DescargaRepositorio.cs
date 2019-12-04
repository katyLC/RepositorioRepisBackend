using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio {


    public class DescargaRepositorio : IDescargaRepositorio
    {

        private readonly AppContext _appContext;

        public DescargaRepositorio(AppContext appContext) {
            _appContext = appContext;
        }

        public async Task RegistrarDescarga(Descargas descargas) {
            await _appContext.Descargas.AddAsync(descargas);
            _appContext.SaveChanges();
        }
    }
}