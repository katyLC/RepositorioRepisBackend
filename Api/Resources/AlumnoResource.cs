using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Api.Resources
{
    public class AlumnoResource
    {
        public int IdAlumno { get; set; }
        public string AlumnoNombre { get; set; }
        public string AlumnoApellidos { get; set; }
        public string AlumnoCodigoUniversitario { get; set; }
        public int  IdCiclo { get; set; }
        public Ciclo Ciclo { get; set; }
    }
}