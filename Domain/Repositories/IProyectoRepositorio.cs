using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IProyectoRepositorio
    {
        List<ProyectoEntity> ListarProyecto();

        Task RegistrarProyecto(Proyecto proyecto);

        IList<ProyectoEntity> detalleProyecto();

        void ActualizarProyecto(Proyecto proyecto);

        Task<Proyecto> BuscarProyectoPorId(int id);
    }
}