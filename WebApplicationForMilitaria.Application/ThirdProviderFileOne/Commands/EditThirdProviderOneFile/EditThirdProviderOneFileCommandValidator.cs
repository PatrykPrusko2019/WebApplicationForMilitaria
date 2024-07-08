
using FluentValidation;
using WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.CreateThirdProviderOneFile;

namespace WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.EditThirdProviderOneFile
{
    public class EditThirdProviderOneFileCommandValidator : AbstractValidator<EditThirdProviderOneFileCommand>
    {
        public EditThirdProviderOneFileCommandValidator()
        {
            RuleFor(p => p.NamePl).NotEmpty().NotNull().WithMessage("Please any select NamePl");
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Please any select Name");
            RuleFor(p => p.NameEn).NotEmpty().NotNull().MinimumLength(4).WithMessage("Choose any NameEn");
            RuleFor(p => p.Description).NotEmpty().NotNull().MinimumLength(10).WithMessage("Choose any adres Description");
            RuleFor(p => p.DescriptionPl).NotEmpty().NotNull().MinimumLength(10).WithMessage("Choose any DescriptionPl");
            RuleFor(p => p.DescriptionEn).NotEmpty().NotNull().WithMessage("Choose any DescriptionEn");
            RuleFor(e => e.Code).NotEmpty().NotEmpty().MinimumLength(4).WithMessage("Please enter: value > 0");
            RuleFor(p => p.Ean).NotEmpty().NotNull().MinimumLength(4).WithMessage("Choose any Ean");
            RuleFor(p => p.SupplierCode).NotEmpty().MinimumLength(4).NotNull().WithMessage("choose any SupplierCode");
            RuleFor(p => p.Size).NotEmpty().NotNull().MinimumLength(4).WithMessage("Choose any Size");
            RuleFor(p => p.Color).NotEmpty().NotNull().MinimumLength(4).WithMessage("Choose any Color");
            RuleFor(p => p.Category).NotEmpty().NotNull().MinimumLength(4).WithMessage("Choose any Category");
            RuleFor(p => p.CategoryPl).NotEmpty().NotNull().MinimumLength(4).WithMessage("Choose any CategoryPl");
            RuleFor(p => p.CategoryEn).NotEmpty().NotNull().MinimumLength(4).WithMessage("Choose any CategoryEn");
        }
    }
}
