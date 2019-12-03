using System;
using System.Threading.Tasks;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.ProyectoAutor {
    public class ProyectoAutorUseCase : IProyectoAutorUseCase {
        private readonly IProyectoAutorRepositorio _proyectoAutorRepositorio;

        public ProyectoAutorUseCase(IProyectoAutorRepositorio proyectoAutorRepositorio) {
            _proyectoAutorRepositorio = proyectoAutorRepositorio;
        }

        public async Task<ProyectoAutorResponse> RegistrarProyectoAutor(Data.DbModel.ProyectoAutor proyectoAutor) {
            try {
                await _proyectoAutorRepositorio.RegistrarProyectoAutor(proyectoAutor);
                return new ProyectoAutorResponse(proyectoAutor);
            }
            catch (Exception e) {
                return new ProyectoAutorResponse($"Error al guardar el autor: {e.Message}");
            }
        }
    }
}