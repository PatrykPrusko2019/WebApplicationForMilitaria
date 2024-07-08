
using MediatR;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileTwo;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.DeleteFirstProviderOneFile
{
    public class DeleteFirstProviderOneFileCommandHandler : IRequestHandler<DeleteFirstProviderOneFileCommand>
    {
        private readonly IFirstProviderOneFileRepository _repository;

        public DeleteFirstProviderOneFileCommandHandler(IFirstProviderOneFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteFirstProviderOneFileCommand request, CancellationToken cancellationToken)
        {
            var deletedProduct = await _repository.GetProductById(request.ProductId);

            await _repository.Delete(deletedProduct);

            return Unit.Value;
        }
    }
}
