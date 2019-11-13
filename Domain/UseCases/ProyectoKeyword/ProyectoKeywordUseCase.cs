using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.Responses;
using RespositorioREPIS.Domain.Validators;

namespace RespositorioREPIS.Domain.UseCases.ProyectoKeyword
{
    public class ProyectoKeywordUseCase : IProyectoKeywordUseCase
    {
        private readonly IProyectoKeywordRepositorio _proyectoKeywordRepositorio;

        public ProyectoKeywordUseCase(IProyectoKeywordRepositorio proyectoKeywordRepositorio)
        {
            _proyectoKeywordRepositorio = proyectoKeywordRepositorio;
        }

        public async Task<ProyectoKeywordResponse> RegistrarProyectoKeyword(
            Data.DbModel.ProyectoKeyword proyectoKeyword)
        {
            try
            {
                await _proyectoKeywordRepositorio.RegistrarProyectoKeyword(proyectoKeyword);
                return new ProyectoKeywordResponse(proyectoKeyword);
            }
            catch (Exception e)
            {
                return new ProyectoKeywordResponse($"Error al guardar los keywords del proyecto: {e.Source}");
            }
        }
    }
}