namespace RespositorioREPIS.Domain.Entities
{
    public class ProyectoEntity
    {
        public int IdProyecto { get; set; }
        public string ProyectoNombre { get; set; }
        public string ProyectoTema { get; set; }
        public string ProyectoGithubUrl { get; set; }
        public string ProyectoDocumentoUrl { get; set; }
        public string ProyectoPortadaUrl { get; set; }
        public int IdCurso { get; set; }
        public int IdPaper { get; set; }
        public int IdEstado { get; set; }

        public virtual CursoEntity Curso { get; set; }

        public ProyectoEntity(string proyectoNombre, string proyectoTema, string proyectoGithubUrl,
            string proyectoDocumentoUrl, string proyectoPortadaUrl, int idCurso, int idPaper, int idEstado)
        {
            ProyectoNombre = proyectoNombre;
            ProyectoTema = proyectoTema;
            ProyectoGithubUrl = proyectoGithubUrl;
            ProyectoDocumentoUrl = proyectoDocumentoUrl;
            ProyectoPortadaUrl = proyectoPortadaUrl;
            IdCurso = idCurso;
            IdPaper = idPaper;
            IdEstado = idEstado;
        }

        public ProyectoEntity()
        {
        }
    }
}