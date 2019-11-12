using System.Collections.Generic;
using System.Linq;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;

namespace RespositorioREPIS.Data.Repositorio
{
    public class PerfilRepositorio : IPerfilRepositorio
    {
        private readonly AppContext _appContext;

        public PerfilRepositorio(AppContext appContext)
        {
            _appContext = appContext;
        }

        public List<PerfilEntity> Listar()
        {
            var perfiles = (from p in _appContext.Perfil
                    select new PerfilEntity()
                    {
                        IdPerfil = p.IdPerfil,
                        PerfilDescripcion = p.PerfilDescripcion,
                        PerfilColor = p.PerfilColor
                    }
                ).ToList();
            return perfiles;
        }
    }
}