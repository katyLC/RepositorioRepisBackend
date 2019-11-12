using System;
using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.UseCases.Proyecto
{
    public class ProyectoUseCase : IProyectoUseCase
    {
        private readonly IProyectoRepositorio _proyectoRepositorio;

        public ProyectoUseCase(IProyectoRepositorio proyectoRepositorio)
        {
            _proyectoRepositorio = proyectoRepositorio;
        }

        public IList<ProyectoEntity> ListarProyecto()
        {
            return _proyectoRepositorio.ListarProyecto();
        }

        public void RegistrarProyecto(string proyectoNombre, string proyectoTema, string proyectoGithubUrl,
            string proyectoDocumentoUrl, string proyectoPortadaUrl, int idCurso, int idPaper, int idEstado)
        {
            _proyectoRepositorio.RegistrarProyecto(new ProyectoEntity(proyectoNombre, proyectoTema,
                proyectoGithubUrl, proyectoDocumentoUrl, proyectoPortadaUrl, idCurso, idPaper, idEstado));
        }

        public IList<ProyectoEntity> detalleProyecto()
        {
            throw new NotImplementedException();
        }
    }
}