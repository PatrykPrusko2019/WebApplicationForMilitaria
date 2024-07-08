
using FluentValidation;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.CreateSecondProviderTwoFile
{
    public class CreateSecondProviderTwoFileCommandValidator : AbstractValidator<CreateSecondProviderTwoFileCommand>
    {
        public CreateSecondProviderTwoFileCommandValidator()
        {
            RuleFor(p => p.Ean).NotEmpty().NotNull().WithMessage("Please any select value");
            RuleFor(p => p.Sku).NotEmpty().NotNull().WithMessage("Please any select value");
            RuleFor(p => p.Name).NotEmpty().NotNull().MinimumLength(4).WithMessage("Choose any name");
            RuleFor(p => p.Url).NotEmpty().NotNull().MinimumLength(10).WithMessage("Choose any adres url");
            RuleFor(p => p.Desc).NotEmpty().NotNull().MinimumLength(10).WithMessage("Choose any Description");
            RuleFor(p => p.Unit).NotEmpty().NotNull().WithMessage("Choose any Unit");
            RuleFor(e => e.Weight).NotEmpty().NotEmpty().WithMessage("Please enter: value > 0");
            RuleFor(p => p.PKWiU).NotEmpty().NotNull().WithMessage("Choose any PKWiU");
            RuleFor(p => p.InStock).NotEmpty().NotNull().WithMessage("Choose any true or false");
            RuleFor(p => p.Qty).NotEmpty().NotNull().WithMessage("Choose any Qty");
            RuleFor(p => p.RequiredBox).NotEmpty().NotNull().WithMessage("Choose any PKWiU");
            RuleFor(p => p.QuantityPerBox).NotEmpty().NotNull().WithMessage("Choose any QuantityPerBox");
            RuleFor(p => p.PriceAfterDiscountNet).NotEmpty().NotNull().WithMessage("Choose any PriceAfterDiscountNet");
            RuleFor(p => p.Vat).NotEmpty().NotNull().WithMessage("Choose any Vat");
            RuleFor(p => p.RetailPriceGross).NotEmpty().NotNull().WithMessage("Choose any RetailPriceGross");

        }
    }
}
