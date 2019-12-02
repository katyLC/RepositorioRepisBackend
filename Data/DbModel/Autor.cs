using System.Collections.Generic;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Autor
    {
        public Autor()
        {
            ProyectoAutor = new HashSet<ProyectoAutor>();
        }

        public int IdAutor { get; set; }
        public string AutorNombreApellido { get; set; }

        public virtual ICollection<ProyectoAutor> ProyectoAutor { get; set; }
    }
}
