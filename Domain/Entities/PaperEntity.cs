using System.Collections.Generic;

namespace RespositorioREPIS.Domain.Entities
{
    public class PaperEntity
    {
        public int IdPaper { get; set; }
        public string PaperResumen { get; set; }
        public string PaperIntroduccion { get; set; }
        public virtual ICollection<ProyectoEntity> Proyecto { get; set; }

        public PaperEntity(string paperResumen, string paperIntroduccion)
        {
            PaperResumen = paperResumen;
            PaperIntroduccion = paperIntroduccion;
        }

        public PaperEntity()
        {
        }
    }
}