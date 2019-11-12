using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.UseCases.Perfil
{
    public interface IPerfilUseCase
    {
        IList<PerfilEntity> Listar();
    }
}