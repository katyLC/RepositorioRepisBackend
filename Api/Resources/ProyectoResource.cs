using System.Collections.Generic;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Api.Resources
{
    public class ProyectoResource
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
        public int IdAlumno { get; set; }
        public Curso Curso { get; set; }
        public Estado Estado { get; set; }
        public Paper Paper { get; set; }
        public Alumno Alumno { get; set; }
        // public List<ProyectoKeyword> ProyectoKeyword { get; set; }
    }
}