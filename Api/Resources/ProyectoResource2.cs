using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Api.Resources {
    public class ProyectoResource2 {
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
        public string CursoNombre { get; set; }
        public string CicloDescripcion { get; set; }
        public string PaperResumen { get; set; }
        public string PaperIntroduccion { get; set; }
        public int IdPerfil { get; set; }
        public string EstadoDescripcion { get; set; }
        public string AlumnoNombre { get; set; }
        public List<string> Autores { get; set; }
        public List<string> Keywords { get; set; }
    }
}