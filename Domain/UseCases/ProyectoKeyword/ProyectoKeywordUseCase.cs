using System;
using FluentValidation.Results;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;
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

        public void RegistrarProyectoKeyword(int idProyecto, int idKeyword)
        {
            _proyectoKeywordRepositorio.RegistrarProyectoKeyword(new ProyectoKeywordEntity(idProyecto, idKeyword));
        }
    }
}