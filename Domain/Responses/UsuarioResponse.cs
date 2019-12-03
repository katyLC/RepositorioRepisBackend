using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Responses {
    public class UsuarioResponse : BaseResponse<Usuario> {

        public UsuarioResponse(Usuario resource) : base(resource) {
        }

        public UsuarioResponse(string message) : base(message) {
        }
    }
}