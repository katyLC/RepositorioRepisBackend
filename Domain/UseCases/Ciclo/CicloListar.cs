using System.Collections.Generic;
using Newtonsoft.Json;
using RespositorioREPIS.Data;
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
        
        public IList<CicloDTO> Listar()
        {
            return _cicloRepository.Listar();
        }


        
    }
}