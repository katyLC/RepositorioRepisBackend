using System;
using System.Threading.Tasks;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Autor {
    public class AutorUseCase : IAutorUseCase {

        private readonly IAutorRepositorio _autorRepositorio;

        public AutorUseCase(IAutorRepositorio autorRepositorio) {
            _autorRepositorio = autorRepositorio;
        }

        public async Task<AutorResponse> RegistrarAutor(Data.DbModel.Autor autor) {
            try {
                await _autorRepositorio.RegistrarAutor(autor);
                return new AutorResponse(autor);
            }
            catch (Exception e) {
                return new AutorResponse($"Error al guardar el autor: {e.Message}");
            }
        }
    }
}