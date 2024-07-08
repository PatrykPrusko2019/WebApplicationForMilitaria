
using MediatR;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.JsonFile.Commands.EditJsonFile
{
    public class EditJsonFileCommandHandler : IRequestHandler<EditJsonFileCommand>
    {
        private readonly IJsonFileRepository _repository;
        private readonly IUserContext _userContext;

        public EditJsonFileCommandHandler(IJsonFileRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditJsonFileCommand request, CancellationToken cancellationToken)
        {
            var recordUpdated = await _repository.GetRecordById(request.Id);

            var user = _userContext.GetCurrentUser();
            var isEditable = (user != null && recordUpdated.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com");

            if (!isEditable) { return Unit.Value; }

            recordUpdated.OccurredAt = request.OccurredAt;
            recordUpdated.Balance.Amount = request.Balance.Amount;
            recordUpdated.Balance.Currency = request.Balance.Currency;
            recordUpdated.Offer.Name = request.Offer.Name;
            recordUpdated.Offer.OfferIdJson = request.Offer.OfferIdJson;
            recordUpdated.Order.OrderIdJson = request.Order.OrderIdJson;
            recordUpdated.Tax.Percentage = request.Tax.Percentage;
            recordUpdated.Type.TypeIdJson = request.Type.TypeIdJson;
            recordUpdated.Type.Name = request.Type.Name;
            recordUpdated.Value.Amount = request.Value.Amount;
            recordUpdated.Value.Currency = request.Value.Currency;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
