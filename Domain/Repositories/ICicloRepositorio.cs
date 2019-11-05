﻿using System.Collections.Generic;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Repositories
{
    public interface ICicloRepositorio
    {
        List<CicloDTO> Listar ();
    }
}