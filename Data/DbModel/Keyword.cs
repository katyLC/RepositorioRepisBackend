using System.Collections.Generic;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Keyword
    {
        public Keyword()
        {
            ProyectoKeyword = new HashSet<ProyectoKeyword>();
        }

        public int IdKeyword { get; set; }
        public string KeywordDescripcion { get; set; }

        public virtual ICollection<ProyectoKeyword> ProyectoKeyword { get; set; }
    }
}
