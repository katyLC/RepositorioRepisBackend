using System.Collections.Generic;
using System.Linq;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.UseCases.PerfilProyecto;

namespace RespositorioREPIS.Data
{
    public class ListarPerfilRepositorio : IListarPerfilProyecto, IListarPerfilProyectoRepositorio
    {
        private readonly AppContext _appContext;

        public ListarPerfilRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        
        
        public IList<Perfil> ListarPerfil()
        {
            return _appContext.Perfil.ToList();
        }
    }
}