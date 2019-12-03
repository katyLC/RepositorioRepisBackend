using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Data;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.Responses;
using RespositorioREPIS.Domain.UseCases.PalabrasClaves;

namespace RespositorioREPIS.Domain.UseCases.PalabrasClaves
{
    public class PalabrasClavesUseCase : IPalabrasClavesUseCase
    {

        private readonly IPalabrasClavesRepositorio _palabrasClavesRepositorio;

        public PalabrasClavesUseCase(IPalabrasClavesRepositorio palabrasClavesRepositorio)
        {
            _palabrasClavesRepositorio = palabrasClavesRepositorio;
        }
        
        public IList<KeywordEntity> ListarPalabrasClaves()
        {
            return _palabrasClavesRepositorio.ListarPalabrasClaves();
        }

        public async Task<KeywordResponse> RegistrarKeyword(Keyword keyword) {
            try {
                await _palabrasClavesRepositorio.RegistrarKeyword(keyword);
                return new KeywordResponse(keyword);
            }
            catch (Exception e) {
                return new KeywordResponse($"Error al guardar el keyword ${e.Message}");
            }
        }
    }
}