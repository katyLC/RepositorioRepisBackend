using System;
using System.Threading.Tasks;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Descargas {
    public class DescargaUseCase : IDescargaUseCase {
        private readonly IDescargaRepositorio _descargaRepositorio;

        public DescargaUseCase(IDescargaRepositorio descargaRepositorio) {
            _descargaRepositorio = descargaRepositorio;
        }

        public async Task<DescargasResponses> RegistrarDescarga(Data.DbModel.Descargas descargas) {
            try {
                await _descargaRepositorio.RegistrarDescarga(descargas);
                return new DescargasResponses(descargas);
            }
            catch (Exception e) {

                return  new DescargasResponses($"Error al gauradar: {e.Message}");
            }
        }
    }
}