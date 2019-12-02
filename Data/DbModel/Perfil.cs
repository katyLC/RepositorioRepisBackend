using System.Collections.Generic;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Perfil
    {
        public Perfil()
        {
            Curso = new HashSet<Curso>();
        }

        public int IdPerfil { get; set; }
        public string PerfilDescripcion { get; set; }
        public string PerfilColor { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}
