using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.UseCases.Perfil
{
    public class PerfilUseCase : IPerfilUseCase
    {
        private readonly IPerfilRepositorio _perfilRepositorio;

        public PerfilUseCase(IPerfilRepositorio perfilRepositorio)
        {
            _perfilRepositorio = perfilRepositorio;
        }

        public IList<PerfilEntity> Listar()
        {
            return _perfilRepositorio.Listar();
        }
    }
}