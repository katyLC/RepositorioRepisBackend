using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Domain.UseCases.PerfilProyecto;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListarPerfilProyecto : Controller
    {
        // GET
        private readonly IListarPerfilProyecto _listarPerfilProyecto;

        public ListarPerfilProyecto(IListarPerfilProyecto listarPerfilProyecto)
        {
            _listarPerfilProyecto = listarPerfilProyecto;
        }
        [HttpGet]
        public IList<Perfil> ListarPerfil()
        {
            return _listarPerfilProyecto.ListarPerfil();
        }
    }
}