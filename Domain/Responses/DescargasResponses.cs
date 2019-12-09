using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Responses {
    public class DescargasResponses : BaseResponse<Descarga> {

        public DescargasResponses(Descarga resource) : base(resource) {
        }

        public DescargasResponses(string message) : base(message) {
        }
    }
}