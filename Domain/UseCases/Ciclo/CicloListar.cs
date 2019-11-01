using System.Collections.Generic;
using Newtonsoft.Json;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.UseCases.Ciclo
{
    public class CicloListar : ICicloListar
    {
        private readonly ICicloRepositorio _cicloRepository;

        public CicloListar(ICicloRepositorio repository)
        {
            _cicloRepository = repository;
        }
        
        public IList<Entities.Ciclo> Listar()
        {
            return _cicloRepository.Listar();
        }


        
    }
}