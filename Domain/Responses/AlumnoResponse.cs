using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Responses {
    public class AlumnoResponse : BaseResponse<Alumno> {
        public AlumnoResponse(Alumno resource) : base(resource) {
        }

        public AlumnoResponse(string message) : base(message) {
        }
    }
}