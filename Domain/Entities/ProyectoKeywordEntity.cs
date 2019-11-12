using System.ComponentModel.DataAnnotations;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Entities
{
    public class ProyectoKeywordEntity
    {
        public int IdProyectoKeyword { get; set; }
        [Required] public int IdProyecto { get; set; }
        [Required] public int IdKeyword { get; set; }

        public virtual Keyword IdKeywordNavigation { get; set; }
        public virtual ProyectoEntity IdProyectoNavigation { get; set; }

        public ProyectoKeywordEntity(int idProyecto, int idKeyword)
        {
            IdProyecto = idProyecto;
            IdKeyword = idKeyword;
        }
    }
}