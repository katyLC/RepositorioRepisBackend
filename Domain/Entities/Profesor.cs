using System;
using System.Collections.Generic;

namespace RespositorioREPIS.Domain.Entities
{
    public partial class Profesor
    {
        public int IdProfesor { get; set; }
        public string ProfesorNombre { get; set; }
        public string ProfesorApellido { get; set; }
        public string ProfesorEmail { get; set; }
    }
}
