using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Autor
    {
        public Autor()
        {
            ProyectoAutor = new HashSet<ProyectoAutor>();
        }
        [Key]
        public int IdAutor { get; set; }
        public int? IdAlumno { get; set; }
        public string AutorNombreApellido { get; set; }

        public virtual Alumno IdAlumnoRepositorioNavigation { get; set; }
        public virtual ICollection<ProyectoAutor> ProyectoAutor { get; set; }
    }
}
