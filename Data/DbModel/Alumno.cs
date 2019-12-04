using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Alumno
    {
        public Alumno()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        public int IdAlumno { get; set; }
        public string AlumnoNombre { get; set; }
        public string AlumnoApellidos { get; set; }
        public string AlumnoCodigoUniversitario { get; set; }
        public string AlumnoEmail { get; set; }
        public int IdCiclo { get; set; }

        public virtual Ciclo Ciclo { get; set; }
        public virtual ICollection<Proyecto> Proyecto { get; set; }
        public virtual ICollection<Descargas> Descargas { get; set; }

        
        public static Alumno FromAlumno(AlumnoEntity alumno)
        {
            return new Alumno()
            {
                IdAlumno = alumno.IdAlumno,
                AlumnoNombre = alumno.AlumnoNombre,
                AlumnoApellidos = alumno.AlumnoApellidos,
                AlumnoCodigoUniversitario = alumno.AlumnoCodigoUniversitario,
                IdCiclo = alumno.IdCiclo
            };
        }
    }
}
