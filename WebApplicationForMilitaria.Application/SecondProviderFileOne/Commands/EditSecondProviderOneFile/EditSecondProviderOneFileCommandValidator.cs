

using FluentValidation;

namespace WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.EditSecondProviderOneFile
{
    public class EditSecondProviderOneFileCommandValidator : AbstractValidator<EditSecondProviderOneFileCommand>
    {
        public EditSecondProviderOneFileCommandValidator()
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
