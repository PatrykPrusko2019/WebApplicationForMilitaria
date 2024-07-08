
using MediatR;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.EditThirdProviderOneFile
{
    public class EditThirdProviderOneFileCommandHandler : IRequestHandler<EditThirdProviderOneFileCommand>
    {
        private readonly IThirdProviderOneFileRepository _repository;
        private readonly IUserContext _userContext;

        public EditThirdProviderOneFileCommandHandler(IThirdProviderOneFileRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditThirdProviderOneFileCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.ProductId);

            var user = _userContext.GetCurrentUser();
            var isEditable = (user != null && product.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com");

            if (!isEditable) { return Unit.Value; }

            product.Name = request.Name;
            product.NamePl = request.NamePl;
            product.NameEn = request.NameEn;
            product.Description = request.Description;
            product.DescriptionPl = request.DescriptionPl;
            product.DescriptionEn = request.DescriptionEn;
            product.Code = request.Code;
            product.Ean = request.Ean;
            product.Status = request.Status;
            product.WholesalePrice = request.WholesalePrice;
            product.SuggestedPrice = request.SuggestedPrice;
            product.SupplierCode = request.SupplierCode;
            product.Vat = request.Vat;
            product.Size = request.Size;
            product.Color = request.Color;
            product.Category = request.Category;
            product.CategoryPl = request.CategoryPl;
            product.CategoryEn = request.CategoryEn;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
