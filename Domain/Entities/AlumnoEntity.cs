namespace RespositorioREPIS.Domain.Entities
{
    public class AlumnoEntity
    {
        public int IdAlumno { get; set; }
        public string AlumnoNombre { get; set; }
        public string AlumnoApellidos { get; set; }
        public string AlumnoCodigoUniversitario { get; set; }
        public int IdCiclo { get; set; }

        public AlumnoEntity(string alumnoNombre, string alumnoApellidos, string alumnoCodigoUniversitario, int idCiclo)
        {
            AlumnoNombre = alumnoNombre;
            AlumnoApellidos = alumnoApellidos;
            AlumnoCodigoUniversitario = alumnoCodigoUniversitario;
            IdCiclo = idCiclo;
        }
    }
}