using System;
using System.Collections.Generic;

namespace RespositorioREPIS.Domain.Entities
{
    public partial class ProyectoKeyword
    {
        public int IdProyectoKeyword { get; set; }
        public int IdProyecto { get; set; }
        public int IdKeyword { get; set; }

        public virtual Keyword IdKeywordNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
