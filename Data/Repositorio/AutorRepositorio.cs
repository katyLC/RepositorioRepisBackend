using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio {
    public class AutorRepositorio : IAutorRepositorio {

        private readonly AppContext _appContext;

        public AutorRepositorio(AppContext appContext) {
            _appContext = appContext;
        }

        public async Task RegistrarAutor(Autor autor) {
            await _appContext.Autor.AddAsync(autor);
            await _appContext.SaveChangesAsync();
        }
    }
}