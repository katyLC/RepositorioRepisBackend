using System;
using System.Collections.Generic;

namespace RespositorioREPIS.Domain.Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string UsuarioCorreo { get; set; }
        public string UsuarioPassword { get; set; }
    }
}
