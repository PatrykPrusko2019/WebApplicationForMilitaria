
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.DeleteSecondProviderOneFile
{
    public class DeleteSecondProviderOneFileCommandHandler : IRequestHandler<DeleteSecondProviderOneFileCommand>
    {
        private readonly ISecondProviderOneFileRepository _repository;

        public DeleteSecondProviderOneFileCommandHandler(ISecondProviderOneFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteSecondProviderOneFileCommand request, CancellationToken cancellationToken)
        {
            var deletedProduct = await _repository.GetProductById(request.Id);

            await _repository.Delete(deletedProduct);

            return Unit.Value;
        }
    }
}
