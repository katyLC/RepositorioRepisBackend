using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.UseCases.Paper
{
    public class PaperUseCase : IPaperUseCase
    {
        private readonly IPaperRepositorio _paperRepositorio;

        public PaperUseCase(IPaperRepositorio paperRepositorio)
        {
            _paperRepositorio = paperRepositorio;
        }

        public void RegistrarPaper(string paperResumen, string paperIntroduccion)
        {
            _paperRepositorio.RegistrarPaperRepositorio(new PaperEntity(paperResumen, paperIntroduccion));
        }
    }
}