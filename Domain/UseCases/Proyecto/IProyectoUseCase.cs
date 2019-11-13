
using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Proyecto
{
    public interface IProyectoUseCase
    {
        IList<ProyectoEntity> ListarProyecto();

        Task<ProyectoResponse> RegistrarProyecto(Data.DbModel.Proyecto proyecto);

        IList<ProyectoEntity> detalleProyecto();

        Task<ProyectoResponse> ActualizarProyecto(int id, Data.DbModel.Proyecto proyecto);

    }
}