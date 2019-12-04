using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio {
   public class AutenticationRepositorio : IAutenticacionRepositorio {

      private readonly AppContext _appContext;

      public AutenticationRepositorio(AppContext appContext) {
         _appContext = appContext;
      }

      public async Task RegistrarUsuario(Usuario usuario) {
         await _appContext.Usuario.AddAsync(usuario);
         _appContext.SaveChanges();
      }

      public async Task RegistrarAlumno(Alumno alumno) {
         await _appContext.Alumno.AddAsync(alumno);
         _appContext.SaveChanges();
      }

      public async Task<Usuario> BuscarUsuarioPorCorreo(string correo) {
         return await _appContext.Usuario.Where(u => u.UsuarioCorreo == correo).FirstAsync();
      }

      public async Task<bool> VerificarPassword(Usuario usuario) {
         var v = await _appContext.Usuario.Where(u => u.UsuarioCorreo == usuario.UsuarioCorreo && u.UsuarioPassword == usuario.UsuarioPassword).FirstAsync();
         return v != null;
      }

      public async Task<Alumno> BuscarAlumno(string correo) {
         return await _appContext.Alumno.Where(a => a.AlumnoEmail == correo).Include("Ciclo").FirstAsync();
      }
   }
}