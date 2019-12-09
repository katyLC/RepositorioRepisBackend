namespace RespositorioREPIS.Data.DbModel {
    public partial class Descarga {

        public int IdDescarga { get; set; }
        public int IdProyecto { get; set; }
        public int IdAlumno { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual Alumno Alumno { get; set; }
    }
}