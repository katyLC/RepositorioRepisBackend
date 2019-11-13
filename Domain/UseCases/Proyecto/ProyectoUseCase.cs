using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.Responses;

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

        public async Task<ProyectoResponse> RegistrarProyecto(Data.DbModel.Proyecto proyecto)
        {
            try
            {
                await _proyectoRepositorio.RegistrarProyecto(proyecto);
                return new ProyectoResponse(proyecto);
            }
            catch (Exception e)
            {
                return new ProyectoResponse($"Error al guardar el proyecto: {e.Message}");
            }
        }

        public IList<ProyectoEntity> detalleProyecto()
        {
            throw new NotImplementedException();
        }

        public async Task<ProyectoResponse> ActualizarProyecto(int id, Data.DbModel.Proyecto proyecto)
        {
            var proyectoActual = await _proyectoRepositorio.BuscarProyectoPorId(id);

            if (proyectoActual == null)
            {
                return new ProyectoResponse("No existe el proyecto.");
            }

            proyectoActual.ProyectoNombre = proyecto.ProyectoNombre;
            proyectoActual.ProyectoTema = proyecto.ProyectoTema;
            proyectoActual.ProyectoGithubUrl = proyecto.ProyectoGithubUrl;
            proyectoActual.ProyectoDocumentoUrl = proyecto.ProyectoDocumentoUrl;
            proyectoActual.ProyectoPortadaUrl = proyecto.ProyectoPortadaUrl;
            proyectoActual.IdCurso = proyecto.IdCurso;
            proyectoActual.IdPaper = proyecto.IdPaper;
            proyectoActual.IdEstado = proyecto.IdEstado;
            
            try
            {
                _proyectoRepositorio.ActualizarProyecto(proyectoActual);
                return new ProyectoResponse(proyectoActual);
            }
            catch (Exception e)
            {
                return new ProyectoResponse($"Error actualizando el proyecto: {e.Message}");
            }
        }
    }
}