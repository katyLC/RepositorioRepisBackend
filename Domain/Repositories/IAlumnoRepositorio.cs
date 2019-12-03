using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IAlumnoRepositorio
    {
        void Create(AlumnoEntity alumno);
        Task<Alumno> ObtenerAlumnID(int id);
    }
}

