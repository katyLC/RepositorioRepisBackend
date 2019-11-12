using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Curso
    {
        public Curso()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        
        [Key] public int IdCurso { get; set; }
        public string CursoNombre { get; set; }
        public int IdCiclo { get; set; }
        public int IdPerfil { get; set; }

        public virtual Ciclo IdCicloNavigation { get; set; }
        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
