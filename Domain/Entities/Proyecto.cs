using System;
using System.Collections;
using System.Collections.Generic;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Domain.Entities
{
    public partial class Proyecto : IProyectoListarRepositorio
    {
        public Proyecto()
        {
            ProyectoAutor = new HashSet<ProyectoAutor>();
            ProyectoKeyword = new HashSet<ProyectoKeyword>();
            Solicitud = new HashSet<Solicitud>();
        }

        public int IdProyecto { get; set; }
        public string ProyectoNombre { get; set; }
        public string ProyectoTema { get; set; }
        public string ProyectoGithubUrl { get; set; }
        public string ProyectoDocumentoUrl { get; set; }
        public string ProyectoPortadaUrl { get; set; }
        public int IdCurso { get; set; }
        public int IdPaper { get; set; }
        public int IdEstado { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Paper IdPaperNavigation { get; set; }
        public virtual ICollection<ProyectoAutor> ProyectoAutor { get; set; }
        public virtual ICollection<ProyectoKeyword> ProyectoKeyword { get; set; }
        public virtual ICollection<Solicitud> Solicitud { get; set; }
        public IList<Proyecto> ListarProyecto()
        {
            throw new NotImplementedException();
        }
    }
}
