using System;
using System.Collections.Generic;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class ProyectoKeyword
    {
        public ProyectoKeyword()
        {
        }

        public int IdProyectoKeyword { get; set; }
        public int IdProyecto { get; set; }
        public int IdKeyword { get; set; }

        public virtual Keyword IdKeywordNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }

        public static ProyectoKeyword FromProyectoKeyword(ProyectoKeywordEntity proyectoKeyword)
        {
            return new ProyectoKeyword()
            {
                IdProyecto = proyectoKeyword.IdProyecto,
                IdKeyword = proyectoKeyword.IdKeyword
            };
        }
    }
}