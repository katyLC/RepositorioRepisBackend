using System;
using System.Collections.Generic;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;
using AppContext = RespositorioREPIS.Data.AppContext;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Proyecto 
    {
        public Proyecto()
        {
            ProyectoAutor = new HashSet<ProyectoAutor>();
            ProyectoKeyword = new HashSet<ProyectoKeyword>();
            Solicitud = new HashSet<Solicitud>();
        }

        public Proyecto(string proyectoNombre, string proyectoTema, string proyectoGithubUrl,
            string proyectoDocumentoUrl, int idCurso)
        {
            ProyectoNombre = proyectoNombre;
            ProyectoTema = proyectoTema;
            ProyectoGithubUrl = proyectoGithubUrl;
            ProyectoDocumentoUrl = proyectoDocumentoUrl;
            IdCurso = idCurso;
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

        public virtual Curso Curso { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Paper Paper { get; set; }
        public virtual ICollection<ProyectoAutor> ProyectoAutor { get; set; }
        public virtual ICollection<ProyectoKeyword> ProyectoKeyword { get; set; }
        public virtual ICollection<Solicitud> Solicitud { get; set; }
        
    }
}