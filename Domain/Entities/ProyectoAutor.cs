using System;
using System.Collections.Generic;

namespace RespositorioREPIS.Domain.Entities
{
    public partial class ProyectoAutor
    {
        public int IdProyectoAutor { get; set; }
        public int IdProyecto { get; set; }
        public int IdAutor { get; set; }

        public virtual Autor IdAutorNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
