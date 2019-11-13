using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Responses
{
    public class PaperResponse : BaseResponse<Paper>
    {
        public PaperResponse(Paper resource) : base(resource)
        {
        }

        public PaperResponse(string message) : base(message)
        {
        }
    }
}