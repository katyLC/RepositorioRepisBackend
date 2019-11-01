using System;
using System.Collections.Generic;

namespace RespositorioREPIS.Domain.Entities
{
    public partial class Solicitud
    {
        public int IdSolicitud { get; set; }
        public string SolicitudDescripcion { get; set; }
        public int IdProyecto { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
