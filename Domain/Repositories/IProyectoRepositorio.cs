using System.Collections.Generic;
using System.Threading.Tasks;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IProyectoRepositorio
    {
        Task<IEnumerable<ProyectoResource2>> ListarProyectos(int idEstado);

        Task RegistrarProyecto(Proyecto proyecto);

        IList<ProyectoEntity> detalleProyecto();

        void ActualizarProyecto(Proyecto proyecto);

        Task<Proyecto> BuscarProyectoPorId(int id);
        Task<IEnumerable<Proyecto>> ObtenerProyectoPorAlumno(int id);
        Task<IEnumerable<Proyecto>> ObtenerProyectoAdministrador();
    }
}