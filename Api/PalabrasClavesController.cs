using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.UseCases.PalabrasClaves;

namespace RespositorioREPIS.Api
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PalabrasClavesController : Controller
    {
        private readonly IPalabrasClaves _palabrasClaves;

        public PalabrasClavesController(IPalabrasClaves palabrasClaves)
        {
            _palabrasClaves = palabrasClaves;
        }

        [HttpGet]
        public IList<KeywordEntity> ListarPalabrasClaves()
        {
            return _palabrasClaves.ListarPalabrasClaves();
        }
        
    }
}