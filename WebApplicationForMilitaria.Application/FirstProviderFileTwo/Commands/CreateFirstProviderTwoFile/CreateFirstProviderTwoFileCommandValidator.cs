
using FluentValidation;

namespace WebApplicationForMilitaria.Application.FirstProviderFileTwo.Commands.CreateFirstProviderTwoFile
{
    public class CreateFirstProviderTwoFileCommandValidator : AbstractValidator<CreateFirstProviderTwoFileCommand>
    {
        public CreateFirstProviderTwoFileCommandValidator()
        {
            RuleFor(p => p.ProducerId).NotEmpty().NotNull().WithMessage("Please any select ProducerId");
            RuleFor(p => p.CategoryId).NotEmpty().NotNull().WithMessage("Please any select CategoryId");
            RuleFor(p => p.UnitId).NotEmpty().NotNull().MinimumLength(4).WithMessage("Choose any UnitId");
            RuleFor(p => p.WarrantyId).NotEmpty().NotNull().MinimumLength(10).WithMessage("Choose any adres WarrantyId");
            RuleFor(p => p.CardUrl).NotEmpty().NotNull().MinimumLength(10).WithMessage("Choose any CardUrl");
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Choose any Name");
            RuleFor(p => p.Description).NotEmpty().NotNull().WithMessage("Choose any Description");
        }

    }
}
