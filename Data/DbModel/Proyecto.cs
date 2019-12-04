using System.Collections.Generic;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            ProyectoAutor = new HashSet<ProyectoAutor>();
            ProyectoKeyword = new HashSet<ProyectoKeyword>();
            Solicitud = new HashSet<Solicitud>();
        }

        public int IdProyecto { get; set; }
        public string ProyectoNombre { get; set; }
        public string ProyectoTema { get; set; }
        public string ProyectoGithubUrl { get; set; }
        public string ProyectoDocumentoUrl { get; set; }
        public string ProyectoPortadaUrl { get; set; }
        public int IdCurso { get; set; }
        public int IdPaper { get; set; }
        public int IdEstado { get; set; }
        public int IdAlumno { get; set; }
        public virtual Alumno Alumno { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Paper Paper { get; set; }
        public virtual ICollection<ProyectoAutor> ProyectoAutor { get; set; }
        public virtual ICollection<ProyectoKeyword> ProyectoKeyword { get; set; }
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
