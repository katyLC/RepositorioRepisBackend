using System.Collections;
using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.UseCases.PerfilProyecto
{
    public interface IListarPerfilProyecto
    {
        IList<Perfil> ListarPerfil();
    }
}