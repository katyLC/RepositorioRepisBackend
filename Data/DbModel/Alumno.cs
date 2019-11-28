using System;
using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Alumno
    {
        public Alumno()
        {
            Autor = new HashSet<Autor>();
        }

        public Alumno(int idAlumno,string alumnoNombre, string alumnoApellidos, string alumnoCodigoUniversitario, int idCiclo)
        {
            IdAlumno = idAlumno;
            AlumnoNombre = alumnoNombre;
            AlumnoApellidos = alumnoApellidos;
            AlumnoCodigoUniversitario = alumnoCodigoUniversitario;
            IdCiclo = idCiclo;
        }

        public int IdAlumno { get; set; }
        public string AlumnoNombre { get; set; }
        public string AlumnoApellidos { get; set; }
        public string AlumnoCodigoUniversitario { get; set; }
        public int IdCiclo { get; set; }
        
        public virtual Ciclo Ciclo { get; set; }
        public virtual ICollection<Autor> Autor { get; set; }
        
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