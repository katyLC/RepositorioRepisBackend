using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Responses
{
    public class ProyectoResponse : BaseResponse<Proyecto>
    {
        public ProyectoResponse(Proyecto proyecto) : base(proyecto)
        {
        }

        public ProyectoResponse(string message) : base(message)
        {
        }
    }
}