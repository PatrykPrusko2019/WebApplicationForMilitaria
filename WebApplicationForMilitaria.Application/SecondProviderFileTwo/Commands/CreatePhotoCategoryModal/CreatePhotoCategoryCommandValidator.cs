
using FluentValidation;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.CreatePhotoCategoryModal
{
    public class CreatePhotoCategoryCommandValidator : AbstractValidator<CreatePhotoCategoryCommand>
    {
        public CreatePhotoCategoryCommandValidator()
        {
            RuleFor(p => p.Url).NotEmpty().NotNull();
            RuleFor(p => p.IsMain).NotNull();
            RuleFor(c => c.CategoryName).NotEmpty().NotNull();
        }
    }
}
