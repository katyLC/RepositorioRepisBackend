using System;
using System.Collections.Generic;
using AppContext = RespositorioREPIS.Data.AppContext;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.Entities
{
    public partial class Alumno : IAlumnoRepositorio
    {
        private readonly AppContext _appContext;

        public Alumno(AppContext appContext)
        {
            _appContext = appContext;
        }


        public Alumno()
        {
            Autor = new HashSet<Autor>();
        }

        public Alumno(string alumnoNombre, string alumnoApellidos, string alumnoCodigoUniversitario, int idCiclo)
        {
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

        public virtual Ciclo IdCicloNavigation { get; set; }
        public virtual ICollection<Autor> Autor { get; set; }


        public void Create(Alumno alumno)
        {
            _appContext.Alumno.Add(Alumno.FromAlumno(alumno));

            _appContext.SaveChanges();
        }

        public static Alumno FromAlumno(Alumno alumno)
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