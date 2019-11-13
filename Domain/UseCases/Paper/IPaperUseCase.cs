using System.Threading.Tasks;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Paper
{
    public interface IPaperUseCase
    {
        Task<PaperResponse> RegistrarPaper(Data.DbModel.Paper paper);
    }
}