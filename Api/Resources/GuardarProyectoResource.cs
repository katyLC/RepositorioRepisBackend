using System.Collections.Generic;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Api.Resources
{
    public class GuardarProyectoResource
    {
        public string ProyectoNombre { get; set; }
        public string ProyectoTema { get; set; }
        public string ProyectoGithubUrl { get; set; }
        public string ProyectoDocumentoUrl { get; set; }
        public string ProyectoPortadaUrl { get; set; }
        public int IdCurso { get; set; }
        public int IdPaper { get; set; }
        public int IdEstado { get; set; }
        public int IdAlumno { get; set; }
    }
}