using System;
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

        public void RegistrarProyectoKeyword(ProyectoKeywordEntity proyectoKeyword)
        {
            _appContext.ProyectoKeyword.Add(ProyectoKeyword.FromProyectoKeyword(proyectoKeyword));
            _appContext.SaveChanges();
        }
    }
}