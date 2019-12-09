using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Responses {
    public class ProfesorResponse : BaseResponse<Profesor> {

        public ProfesorResponse(Profesor resource) : base(resource) {
        }

        public ProfesorResponse(string message) : base(message) {
        }
    }
}