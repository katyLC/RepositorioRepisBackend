using System;
using System.Collections.Generic;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.Entities
{
    public partial class Ciclo
    {
        public Ciclo()
        {
            Alumno = new HashSet<Alumno>();
            Curso = new HashSet<Curso>();
        }

        public Ciclo(int idCiclo, string cicloDescripcion, ICollection<Alumno> alumno,
            ICollection<Curso> curso)
        {
            IdCiclo = idCiclo;
            CicloDescripcion = cicloDescripcion;
            Alumno = alumno;
            Curso = curso;
        }

        public Ciclo(int idCiclo, string cicloDescripcion)
        {
            IdCiclo = idCiclo;
            CicloDescripcion = cicloDescripcion;
        }

        public int IdCiclo { get; set; }
        public string CicloDescripcion { get; set; }

        public virtual ICollection<Alumno> Alumno { get; set; }
        public virtual ICollection<Curso> Curso { get; set; }
    }
}