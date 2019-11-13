using FluentValidation;
using RespositorioREPIS.Api;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.Validators
{
    public class ProyectoKeywordValidation /*: AbstractValidator<ProyectoKeyword>*/
    {
        public ProyectoKeywordValidation()
        {
//            RuleFor(x => x.IdProyecto).NotNull().NotEmpty().WithMessage("No hay proyecto");
//            RuleFor(x => x.IdKeyword).NotNull().WithMessage("No hay keyword");
        }
    }
}