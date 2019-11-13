using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Responses
{
    public class ProyectoKeywordResponse : BaseResponse<ProyectoKeyword>
    {
        public ProyectoKeywordResponse(ProyectoKeyword resource) : base(resource)
        {
        }

        public ProyectoKeywordResponse(string message) : base(message)
        {
        }
    }
}