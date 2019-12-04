using Microsoft.IdentityModel.Tokens;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Api.Resources {
    public class AuthResource {
        public string Role;
        public Data Data;
    }
    public class Data {
        public string Token;
        public int IdAlumno;
        public string CicloDescripcion;
        public string AlumnoNombre;
        public string AlumnoApellidos;
        public string AlumnoCodigoUniversitario;
        public string AlumnoEmail;
    }
}