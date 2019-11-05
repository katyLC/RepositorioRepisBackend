using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.UseCases.PerfilProyecto
{
    public class PerfilListar: IListarPerfilProyecto
    {
        private readonly IPerfilesRepositorio _perfilesRepositorio;

        public PerfilListar(IPerfilesRepositorio perfilesRepositorio)
        {
            _perfilesRepositorio = perfilesRepositorio;
        }

        public IList<Perfil> ListarPerfil()
        {
            return _perfilesRepositorio.ListarPerfil();
            
        }

    }
}