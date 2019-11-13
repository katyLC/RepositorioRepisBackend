using System;
using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Paper
    {
        public Paper()
        {
//            PaperAdicional = new HashSet<PaperAdicional>();
            Proyecto = new HashSet<Proyecto>();
        }

        public int IdPaper { get; set; }
        public string PaperResumen { get; set; }
        public string PaperIntroduccion { get; set; }

//        public virtual ICollection<PaperAdicional> PaperAdicional { get; set; }
        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}