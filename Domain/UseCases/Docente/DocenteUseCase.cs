using System;
using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Docente

{
    public class DocenteUseCase : IDocenteUseCase
    {
        private readonly IDocenteRepositorio _docenteRepositorio;

        public DocenteUseCase(IDocenteRepositorio docenteRepositorio)
        {
            _docenteRepositorio = docenteRepositorio;
        }
        
        public async Task<ProfesorResponse> RegistrarDocente(Profesor profesor)
        {
            try {
                await _docenteRepositorio.RegistrarDocente(profesor);
                return new ProfesorResponse(profesor);
            }
            catch (Exception e) {
                return new ProfesorResponse($"Error al guardar el profesor: {e.Message}");
            }
        }
    }
}