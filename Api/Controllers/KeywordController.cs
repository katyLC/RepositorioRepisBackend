using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Domain.UseCases.PalabrasClaves;

namespace RespositorioREPIS.Api.Controllers {
    public class KeywordController : Controller {
        private readonly IPalabrasClavesUseCase _palabrasClavesUseCase;
        private readonly IMapper _mapper;

        public KeywordController(IPalabrasClavesUseCase palabrasClavesUseCase, IMapper mapper) {
            _palabrasClavesUseCase = palabrasClavesUseCase;
            _mapper = mapper;
        }


    }
}