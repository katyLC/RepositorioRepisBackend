using System;
using System.Collections.Generic;

namespace RespositorioREPIS.Domain.Entities
{
    public partial class Autor
    {
        public Autor()
        {
            ProyectoAutor = new HashSet<ProyectoAutor>();
        }

        public int IdAutor { get; set; }
        public int? IdAlumno { get; set; }
        public string AutorNombreApellido { get; set; }

        public virtual AlumnoRepositorio IdAlumnoRepositorioNavigation { get; set; }
        public virtual ICollection<ProyectoAutor> ProyectoAutor { get; set; }
    }
}
