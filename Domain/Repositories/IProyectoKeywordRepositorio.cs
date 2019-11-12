using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface IProyectoKeywordRepositorio
    {
        void RegistrarProyectoKeyword(ProyectoKeywordEntity proyectoKeyword);
    }
}