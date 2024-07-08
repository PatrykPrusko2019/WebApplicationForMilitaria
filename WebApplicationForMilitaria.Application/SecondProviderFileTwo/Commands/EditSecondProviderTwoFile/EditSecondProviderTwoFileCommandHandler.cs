
using MediatR;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.EditSecondProviderTwoFile
{
    public class EditSecondProviderTwoFileCommandHandler : IRequestHandler<EditSecondProviderTwoFileCommand>
    {
        private readonly ISecondProviderTwoFileRepository _repository;
        private readonly IUserContext _userContext;

        public EditSecondProviderTwoFileCommandHandler(ISecondProviderTwoFileRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditSecondProviderTwoFileCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.ProductId);

            var user = _userContext.GetCurrentUser();
            var isEditable = (user != null && product.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com");


            if (!isEditable) { return Unit.Value; }

            product.Ean = request.Ean;
            product.Sku = request.Sku;
            product.Name = request.Name;
            product.Desc = request.Desc;
            product.Url = request.Url;
            product.Unit = request.Unit;
            product.Weight = request.Weight;
            product.PKWiU = request.PKWiU;
            product.InStock = request.InStock;
            product.Qty = request.Qty;
            product.RequiredBox = request.RequiredBox;
            product.QuantityPerBox = request.QuantityPerBox;
            product.PriceAfterDiscountNet = request.PriceAfterDiscountNet;
            product.Vat = request.Vat;
            product.RetailPriceGross = request.Qty;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
