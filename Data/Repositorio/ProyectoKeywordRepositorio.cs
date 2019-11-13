using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class ProyectoKeywordRepositorio : IProyectoKeywordRepositorio
    {
        private readonly AppContext _appContext;

        public ProyectoKeywordRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task RegistrarProyectoKeyword(ProyectoKeyword proyectoKeyword)
        {
            await _appContext.ProyectoKeyword.AddAsync(proyectoKeyword);
            _appContext.SaveChanges();
        }
    }
}