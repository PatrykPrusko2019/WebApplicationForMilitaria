
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.FirstProviderFileTwo.Commands.DeleteFirstProviderTwoFile
{
    public class DeleteFirstProviderTwoFileCommandHandler : IRequestHandler<DeleteFirstProviderTwoFileCommand>
    {
        private readonly IFIrstProviderTwoFileRepository _repository;

        public DeleteFirstProviderTwoFileCommandHandler(IFIrstProviderTwoFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteFirstProviderTwoFileCommand request, CancellationToken cancellationToken)
        {
            var deletedRecord = await _repository.GetProductById(request.Id);

            await _repository.Delete(deletedRecord);

            return Unit.Value;
        }
    }
}
