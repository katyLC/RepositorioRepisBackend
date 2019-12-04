using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Entities
{
    public class CursosEntity
    {
        public int IdCurso { get; set; }
        public string CursoNombre { get; set; }
        public int IdProfesor { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}