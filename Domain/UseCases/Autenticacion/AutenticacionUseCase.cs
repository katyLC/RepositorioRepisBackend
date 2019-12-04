using System;
using System.Threading.Tasks;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.Responses;

namespace RespositorioREPIS.Domain.UseCases.Autenticacion {
    public class AutenticacionUseCase : IAutenticacionUseCase {

        private readonly IAutenticacionRepositorio _autenticacionRepositorio;

        public AutenticacionUseCase(IAutenticacionRepositorio autenticacionRepositorio) {
            _autenticacionRepositorio = autenticacionRepositorio;
        }

        public async Task<AlumnoResponse> RegistrarAlumno(Data.DbModel.Alumno alumno) {
            try {
                await _autenticacionRepositorio.RegistrarAlumno(alumno);
                return new AlumnoResponse(alumno);
            }
            catch (Exception e) {
                return new AlumnoResponse($"Error al guardar el alumno: {e.Message}");
            }
        }

        public async Task<UsuarioResponse> RegistrarUsuario(Data.DbModel.Usuario usuario) {
            try {
                await _autenticacionRepositorio.RegistrarUsuario(usuario);
                return new UsuarioResponse(usuario);
            }
            catch (Exception e) {
                return new UsuarioResponse($"Error al guardar el usuario: {e.Message}");
            }
        }

        public async Task<bool> VerificarPassword(Data.DbModel.Usuario usuario) {
            try {
                await _autenticacionRepositorio.VerificarPassword(usuario);
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

        public async Task<Data.DbModel.Usuario> BuscarUsuarioPorCorreo(string correo) {
            return await _autenticacionRepositorio.BuscarUsuarioPorCorreo(correo);
        }

        public async Task<Data.DbModel.Alumno> BuscarAlumno(string correo) {
            return await _autenticacionRepositorio.BuscarAlumno(correo);
        }
    }
}