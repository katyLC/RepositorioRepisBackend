using System;
using System.Threading.Tasks;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Paper
{
    public class PaperUseCase : IPaperUseCase
    {
        private readonly IPaperRepositorio _paperRepositorio;

        public PaperUseCase(IPaperRepositorio paperRepositorio)
        {
            _paperRepositorio = paperRepositorio;
        }

        public async Task<PaperResponse> RegistrarPaper(Data.DbModel.Paper paper)
        {
            try
            {
                await _paperRepositorio.RegistrarPaperRepositorio(paper);
                return new PaperResponse(paper);
            }
            catch (Exception e)
            {
                return new PaperResponse($"Error al guardar el paper: {e.Message}");
            }
        }
    }
}