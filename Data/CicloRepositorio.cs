﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data
{
    public class CicloRepositorio : ICicloRepositorio
    {
        private readonly AppContext _appContext;

        public CicloRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IList<Ciclo> Listar()
        {
            return _appContext.Ciclo.ToList();
        }
    }
}