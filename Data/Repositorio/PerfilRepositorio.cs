using System.Collections.Generic;
using System.Linq;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.UseCases.PerfilProyecto;

namespace RespositorioREPIS.Data
{
    public class PerfilRepositorio : IListarPerfilProyecto, IPerfilesRepositorio
    {
        private readonly AppContext _appContext;

        public PerfilRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        
        
        public IList<Perfil> ListarPerfil()
        {
            return _appContext.Perfil.ToList();
        }
    }
}