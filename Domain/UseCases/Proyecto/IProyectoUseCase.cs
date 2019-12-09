
using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Proyecto
{
    public interface IProyectoUseCase
    {
        Task<IEnumerable<ProyectoResource2>> ListarProyectos(int idEstado);

        Task<ProyectoResponse> RegistrarProyecto(Data.DbModel.Proyecto proyecto);

        IList<ProyectoEntity> detalleProyecto();

        Task<ProyectoResponse> ActualizarProyecto(ActualizarProyectoEstado actualizarProyectoEstado);

        Task<Data.DbModel.Proyecto> BuscarProyectoPorId(int id);
        
        Task<IEnumerable<Data.DbModel.Proyecto>>ObtenerProyectoPorAlumno(int id);
        Task<IEnumerable<Data.DbModel.Proyecto>> ObtenerProyectoAdmintrador();

    }
}