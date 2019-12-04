using Microsoft.IdentityModel.Tokens;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Api.Resources {
    public class AuthResource {
        public string Token;
        public string Role;
        public int IdAlumno;
        public string CicloDescripcion;
        public string AlumnoNombre;
        public string AlumnoApellidos;
        public string AlumnoCodigoUniversitario;
        public string AlumnoEmail;
    }
}