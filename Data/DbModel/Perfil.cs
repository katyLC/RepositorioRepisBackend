using System.Collections.Generic;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Perfil
    {
        public Perfil(int idPerfil, string perfilDescripcion, string perfilColor, ICollection<Curso> curso)
        {
            IdPerfil = idPerfil;
            PerfilDescripcion = perfilDescripcion;
            PerfilColor = perfilColor;
            Curso = curso;
        }

        public Perfil()
        {
            Curso = new HashSet<Curso>();
        }

        public Perfil(int idPerfil, string perfilDescripcion, string perfilColor)
        {
            IdPerfil = idPerfil;
            PerfilDescripcion = perfilDescripcion;
            PerfilColor = perfilColor;
        }

        public int IdPerfil { get; set; }
        public string PerfilDescripcion { get; set; }
        public string PerfilColor { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}