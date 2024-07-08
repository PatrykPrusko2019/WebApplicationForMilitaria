
using MediatR;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.EditSecondProviderOneFile
{
    public class EditSecondProviderOneFileCommandHandler : IRequestHandler<EditSecondProviderOneFileCommand>
    {
        private readonly ISecondProviderOneFileRepository _repository;
        private readonly IUserContext _userContext;
        public EditSecondProviderOneFileCommandHandler(ISecondProviderOneFileRepository secondProviderOneFileRepository, IUserContext userContext)
        {
            _repository = secondProviderOneFileRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditSecondProviderOneFileCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);

            var user = _userContext.GetCurrentUser();
            var isEditable = (user != null && product.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com");

            if (!isEditable) { return Unit.Value; }

            product.Ean = request.Ean;
            product.Sku = request.Sku;
            product.InStock = request.InStock;
            product.Availability = request.Availability;
            product.Qty = request.Qty;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
