using System.Collections.Generic;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Profesor
    {
        public Profesor(string profesorNombre, string profesorApellido, string profesorEmail)
        {
            ProfesorNombre = profesorNombre;
            ProfesorApellido = profesorApellido;
            ProfesorEmail = profesorEmail;
        }

        public Profesor()
        {
            Curso = new HashSet<Curso>();
        }
        
        

        public int IdProfesor { get; set; }
        public string ProfesorNombre { get; set; }
        public string ProfesorApellido { get; set; }
        public string ProfesorEmail { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
        
        public static Profesor FromProfesor(Profesor profesorw)
        {
            return new Profesor()
            {
                ProfesorNombre = profesorw.ProfesorNombre,
                ProfesorApellido = profesorw.ProfesorApellido,
                ProfesorEmail = profesorw.ProfesorEmail
            };
        }
    }
}
