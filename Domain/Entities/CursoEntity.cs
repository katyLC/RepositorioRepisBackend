namespace RespositorioREPIS.Domain.Entities
{
    public class CursoEntity
    {
        public int IdCurso { get; set; }
        public string CursoNombre { get; set; }
        public virtual PerfilEntity Perfil { get; set; }
    }
}