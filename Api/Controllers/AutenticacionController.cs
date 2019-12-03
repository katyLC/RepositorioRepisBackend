using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RespositorioREPIS.Api.Resources;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.UseCases.Autenticacion;

namespace RespositorioREPIS.Api.Controllers {
    public class AutenticacionController : Controller {
        private readonly IAutenticacionUseCase _autenticacionUseCase;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AutenticacionController(IAutenticacionUseCase autenticacionUseCase, IMapper mapper,
            IConfiguration configuration) {
            _autenticacionUseCase = autenticacionUseCase;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(AlumnoResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> Registrar([FromBody] AlumnoResource resource) {
            if (resource != null) {
                var alumno = _mapper.Map<AlumnoResource, Alumno>(resource);
                var resultAlumno = await _autenticacionUseCase.RegistrarAlumno(alumno);
                if (!resultAlumno.Success) {
                    return BadRequest(new ErrorResource(resultAlumno.Message));
                }

                var resultUsuario = await _autenticacionUseCase.RegistrarUsuario(new Usuario {
                    UsuarioCorreo = resource.AlumnoEmail,
                    UsuarioPassword = resource.Password
                });
                if (!resultUsuario.Success) {
                    return BadRequest(new ErrorResource(resultUsuario.Message));
                }
            }

            return Ok("Guardado correctamente");
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(AuthResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<AuthResource> Login([FromBody] UsuarioResource usuarioResource) {
            if (usuarioResource == null) return null;
            var usuario = await _autenticacionUseCase.BuscarUsuarioPorCorreo(usuarioResource.UsuarioCorreo);
            if (usuario == null) return null;
            var validarPassword = await _autenticacionUseCase.VerificarPassword(usuario);

            if (!validarPassword) return null;
            var alumno = await _autenticacionUseCase.BuscarAlumno(usuario.UsuarioCorreo);

            if (alumno == null) return null;
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioCorreo)
            };

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthResource {
                Token = tokenHandler.WriteToken(createdToken),
                IdAlumno = alumno.IdAlumno,
                CicloDescripcion = alumno.Ciclo.CicloDescripcion,
                AlumnoNombre = alumno.AlumnoNombre,
                AlumnoApellidos = alumno.AlumnoApellidos,
                AlumnoEmail = alumno.AlumnoEmail,
                AlumnoCodigoUniversitario = alumno.AlumnoCodigoUniversitario
            };
        }
    }
}