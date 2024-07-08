
using FluentValidation;

namespace WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.CreateFirstProviderOneFileCommand
{
    public class CreateFirstProviderOneFileCommandValidator : AbstractValidator<CreateFirstProviderOneFileCommand>
    {
        public CreateFirstProviderOneFileCommandValidator()
        {
            RuleFor(s => s.Size.CodeProducer)
                .NotEmpty().WithMessage("please select anything value !");

            RuleFor(s => s.Size.Code)
                .NotEmpty().WithMessage("please select anything value !");

            RuleFor(s => s.Size.Stock)
                .NotEmpty().WithMessage("please select anything value !");
        }
    }
}
