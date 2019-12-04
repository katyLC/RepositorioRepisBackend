using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Domain.UseCases.Descargas;
using RespositorioREPIS.Domain.UseCases.Paper;

namespace RespositorioREPIS.Data.Repositorio {
    public class DescargaController : Controller {

        private readonly IDescargaUseCase _descargaUseCase;
        private readonly IMapper _mapper;


        public DescargaController(IDescargaUseCase descargaUseCase, IMapper mapper)
        {
            _descargaUseCase = descargaUseCase;
            _mapper = mapper;
        }
    }
}