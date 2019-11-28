
using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Proyecto
{
    public interface IProyectoUseCase
    {
        Task<IEnumerable<Data.DbModel.Proyecto>> ListarProyectos();

        Task<ProyectoResponse> RegistrarProyecto(Data.DbModel.Proyecto proyecto);

        IList<ProyectoEntity> detalleProyecto();

        Task<ProyectoResponse> ActualizarProyecto(int id, Data.DbModel.Proyecto proyecto);

        Task<Data.DbModel.Proyecto> BuscarProyectoPorId(int id);
    }
}