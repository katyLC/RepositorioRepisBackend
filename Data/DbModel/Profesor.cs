using System;
using System.Collections.Generic;

namespace RespositorioREPIS.Data.DbModel
{
    public partial class Profesor
    {
        public int IdProfesor { get; set; }
        public string ProfesorNombre { get; set; }
        public string ProfesorApellido { get; set; }
        public string ProfesorEmail { get; set; }
    }
}
