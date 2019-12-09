using System;
using System.Threading.Tasks;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Descargas
{
    public class DescargasUseCase : IDescargaUseCase
    {
        private readonly IDescargasRepositorio _descargasRepositorio;

        public DescargasUseCase(IDescargasRepositorio descargasRepositorio)
        {
            _descargasRepositorio = descargasRepositorio;
        }

        public async Task<DescargasResponses> RegistrarDescarga(Data.DbModel.Descarga descarga)
        {
            try
            {
                await _descargasRepositorio.RegistrarDescarga(descarga);
                return new DescargasResponses(descarga);
            }
            catch (Exception e)
            {
                return new DescargasResponses($"Erro al guardar: {e.Message}");
            }
        }
    }
}