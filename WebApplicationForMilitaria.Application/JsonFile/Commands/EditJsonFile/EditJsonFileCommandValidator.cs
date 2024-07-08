
using FluentValidation;
using WebApplicationForMilitaria.Application.JsonFile.Commands.CreateJsonFile;

namespace WebApplicationForMilitaria.Application.JsonFile.Commands.EditJsonFile
{
    public class EditJsonFileCommandValidator : AbstractValidator<EditJsonFileCommand>
    {
        public EditJsonFileCommandValidator()
        {
            RuleFor(p => p.Value.Currency).NotEmpty().NotNull().WithMessage("Please any select Currency");
            RuleFor(p => p.Type.Name).NotEmpty().NotNull().WithMessage("Please any select Name");
            RuleFor(p => p.Type.TypeIdJson).NotEmpty().NotNull().MinimumLength(4).WithMessage("Choose any TypeIdJson");
            RuleFor(p => p.Offer.Name).NotEmpty().NotNull().MinimumLength(10).WithMessage("Choose any Name");
            RuleFor(p => p.Offer.OfferIdJson).NotEmpty().NotNull().MinimumLength(10).WithMessage("Choose any OfferIdJson");
            RuleFor(p => p.Tax.Percentage).NotEmpty().NotNull().WithMessage("Choose any Percentage");
            RuleFor(e => e.Balance.Currency).NotEmpty().NotEmpty().WithMessage("Please enter: value > 0");
            RuleFor(p => p.Balance.Amount).NotEmpty().NotNull().WithMessage("Choose any PKWiUAmount");
            RuleFor(p => p.Order.OrderIdJson).NotEmpty().NotNull().WithMessage("Choose any true or OrderIdJson");
        }
    }
}
