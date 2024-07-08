
using FluentValidation;

namespace WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.EditProductByIdFirstProviderOneFileCommand
{
    public class EditProductByIdFirstProviderOneFIleCommandValidator : AbstractValidator<EditProductByIdFirstProviderOneFIleCommand>
    {
        public EditProductByIdFirstProviderOneFIleCommandValidator()
        {
            RuleFor(s => s.Size.CodeProducer)
                .NotEmpty().NotNull().MinimumLength(5).WithMessage("please select anything value !");

            RuleFor(s => s.Size.Code)
                .NotEmpty().NotNull().MinimumLength(5).WithMessage("please select anything value !");

            RuleFor(s => s.Size.Stock)
                .NotEmpty().WithMessage("please select anything value !");


        }
    }
}
