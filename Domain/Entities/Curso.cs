using System;
using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Entities
{
    public partial class Curso
    {
        public Curso()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        public int IdCurso { get; set; }
        public string CursoNombre { get; set; }
        public int IdCiclo { get; set; }
        public int IdPerfil { get; set; }

        public virtual Ciclo IdCicloNavigation { get; set; }
        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
