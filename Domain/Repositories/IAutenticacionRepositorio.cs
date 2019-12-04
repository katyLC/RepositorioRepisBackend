using System.Threading.Tasks;
using Microsoft.Win32;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Repositories {
    public interface IAutenticacionRepositorio {
        Task RegistrarUsuario(Usuario usuario);
        Task RegistrarAlumno(Alumno alumno);
        Task<Usuario> BuscarUsuarioPorCorreo(string correo);
        Task<bool> VerificarPassword(Usuario usuario);
        Task<Alumno> BuscarAlumno(string correo);
    }
}