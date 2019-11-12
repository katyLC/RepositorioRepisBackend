using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.UseCases.Ciclo
{
    public class CicloUseCase : ICicloUseCase
    {
        private readonly ICicloRepositorio _cicloCicloRepositorio;

        public CicloUseCase(ICicloRepositorio cicloRepositorio)
        {
            _cicloCicloRepositorio = cicloRepositorio;
        }

        public IList<CicloEntity> Listar()
        {
            return _cicloCicloRepositorio.Listar();
        }
    }
}