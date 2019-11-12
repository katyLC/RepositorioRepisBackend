using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Domain.UseCases.Paper;

namespace RespositorioREPIS.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaperController : Controller
    {
        private readonly IPaperUseCase _paperUseCase;

        public PaperController(IPaperUseCase paperUseCase)
        {
            _paperUseCase = paperUseCase;
        }

        [HttpPost]
        public void RegistrarPaper([FromBody] PaperCommand paper)
        {
            _paperUseCase.RegistrarPaper(paper.PaperResumen, paper.PaperIntroduccion);
        }
    }

    public class PaperCommand
    {
        public string PaperResumen { get; set; }
        public string PaperIntroduccion { get; set; }
    }
}