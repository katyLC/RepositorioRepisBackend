using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RespositorioREPIS.Domain.UseCases.ProyectoKeyword;

namespace RespositorioREPIS.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoKeywordController : Controller
    {
        private readonly IProyectoKeywordUseCase _proyectoKeywordUseCase;

        public ProyectoKeywordController(IProyectoKeywordUseCase proyectoKeywordUseCase)
        {
            _proyectoKeywordUseCase = proyectoKeywordUseCase;
        }

        [HttpPost]
        public void RegistrarProyectoKeyword([FromBody] List<ProyectoKeywordCommand> proyectoKeywords)
        {
            foreach (var proyectoKeyword in proyectoKeywords)
            {
//            try
//            {
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }
//                else
//                {
                _proyectoKeywordUseCase.RegistrarProyectoKeyword(proyectoKeyword.IdProyecto,
                    proyectoKeyword.IdKeyword);
//                    return Ok(proyectoKeywords);
//                }
//            }
//            catch (Exception e)
//            {
//                return NoContent();
//            }
//            }
            }
        }

        public class ProyectoKeywordCommand
        {
            public int IdProyecto { get; set; }

            public int IdKeyword { get; set; }
        }
    }
}