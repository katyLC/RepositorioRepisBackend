using System;
using System.Collections.Generic;
using AppContext = RespositorioREPIS.Data.AppContext;

using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.Entities
{
    public partial class AlumnoRepositorio:  IAlumnoRepositorio
    {
        private readonly AppContext _appContext;

        public AlumnoRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }


        public AlumnoRepositorio()
        {
            Autor = new HashSet<Autor>();
        }

        public AlumnoRepositorio( string alumnoNombre, string alumnoApellidos, string alumnoCodigoUniversitario, int idCiclo)
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
        
         
        public void Create(AlumnoRepositorio alumnoRepositorio)
        {
            _appContext.Alumno.Add(AlumnoRepositorio.FromAlumno(alumnoRepositorio));
            
            _appContext.SaveChanges();
        }

        public static AlumnoRepositorio FromAlumno(AlumnoRepositorio alumnoRepositorio)
        {
            return new AlumnoRepositorio()
            {
                IdAlumno = alumnoRepositorio.IdAlumno,
                AlumnoNombre = alumnoRepositorio.AlumnoNombre,
                AlumnoApellidos = alumnoRepositorio.AlumnoApellidos,
                AlumnoCodigoUniversitario = alumnoRepositorio.AlumnoCodigoUniversitario,
                IdCiclo = alumnoRepositorio.IdCiclo
                
            };
        }
    }
}
