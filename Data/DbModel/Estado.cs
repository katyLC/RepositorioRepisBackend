using System;
using System.Collections.Generic;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Estado
    {
        public Estado()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        public int IdEstado { get; set; }
        public string EstadoDescripcion { get; set; }

        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
