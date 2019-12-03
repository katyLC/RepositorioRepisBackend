using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Responses {
    public class AutorResponse : BaseResponse<Autor> {

        public AutorResponse(Autor resource) : base(resource) {
        }

        public AutorResponse(string message) : base(message) {
        }
    }
}