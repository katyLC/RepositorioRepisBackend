using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.UseCases.PerfilProyecto
{
    public class ListarPerfilProyecto: IListarPerfilProyecto
    {
        private readonly IListarPerfilProyectoRepositorio _listarPerfilProyectoRepositorio;

        public ListarPerfilProyecto(IListarPerfilProyectoRepositorio listarPerfilProyectoRepositorio)
        {
            _listarPerfilProyectoRepositorio = listarPerfilProyectoRepositorio;
        }

        public IList<Perfil> ListarPerfil()
        {
            return _listarPerfilProyectoRepositorio.ListarPerfil();
        }
    }
}