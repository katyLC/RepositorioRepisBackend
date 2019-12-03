using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio {
    public class ProyectoAutorRepositorio : IProyectoAutorRepositorio {
        private readonly AppContext _appContext;

        public ProyectoAutorRepositorio(AppContext appContext) {
            _appContext = appContext;
        }

        public async Task RegistrarProyectoAutor(ProyectoAutor proyectoAutor) {
            await _appContext.ProyectoAutor.AddAsync(proyectoAutor);
            await _appContext.SaveChangesAsync();
        }
    }
}