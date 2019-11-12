using System;
using System.Collections.Generic;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class PaperAdicional
    {
        public int IdPaperAdicional { get; set; }
        public string PaperAdicionalTitulo { get; set; }
        public string PaperAdicionalDetalle { get; set; }
        public int IdPaper { get; set; }

        public virtual Paper IdPaperNavigation { get; set; }
    }
}
