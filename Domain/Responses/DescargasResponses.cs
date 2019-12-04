using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Responses {
    public class DescargasResponses : BaseResponse<Descargas> {

        public DescargasResponses(Descargas resource) : base(resource) {
        }

        public DescargasResponses(string message) : base(message) {
        }
    }
}