using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Responses {
    public class ProyectoAutorResponse : BaseResponse<ProyectoAutor> {

        public ProyectoAutorResponse(ProyectoAutor resource) : base(resource) {
        }

        public ProyectoAutorResponse(string message) : base(message) {
        }
    }
}