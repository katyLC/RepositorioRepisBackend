using Microsoft.EntityFrameworkCore.Update.Internal;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Responses {
    public class KeywordResponse : BaseResponse<Keyword> {

        public KeywordResponse(Keyword resource) : base(resource) {
        }

        public KeywordResponse(string message) : base(message) {
        }
    }
}