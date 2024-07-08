
using FluentValidation;

namespace WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.CreateSecondProviderOneFile
{
    public class CreateSecondProviderOneFileCommandValidator : AbstractValidator<CreateSecondProviderOneFileCommand>
    {
        public CreateSecondProviderOneFileCommandValidator()
        {
            RuleFor(e => e.Ean)
                .NotEmpty().WithMessage("please select any value !");

            RuleFor(s => s.Sku)
                .NotEmpty().WithMessage("please select any value !");

            RuleFor(s => s.InStock)
                .NotEmpty().WithMessage("please select any value !");

            RuleFor(s => s.InStock)
                .NotEmpty().WithMessage("please select any value !");

            RuleFor(s => s.Qty)
                .NotEmpty().WithMessage("please select any value !");

            RuleFor(s => s.Availability)
                .NotEmpty().WithMessage("please select any value !");

        }
    }
}
