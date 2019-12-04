using System.Threading.Tasks;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Autenticacion {
    public interface IAutenticacionUseCase {
        Task<AlumnoResponse> RegistrarAlumno(Data.DbModel.Alumno alumno);
        Task<UsuarioResponse> RegistrarUsuario(Data.DbModel.Usuario usuario);
        Task<bool> VerificarPassword(Data.DbModel.Usuario usuario);
        Task<Data.DbModel.Usuario> BuscarUsuarioPorCorreo(string correo);
        Task<Data.DbModel.Alumno> BuscarAlumno(string correo);
    }
}