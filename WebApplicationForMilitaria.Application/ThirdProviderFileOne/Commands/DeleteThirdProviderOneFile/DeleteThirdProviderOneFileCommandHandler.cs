
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.DeleteThirdProviderOneFile
{
    public class DeleteThirdProviderOneFileCommandHandler : IRequestHandler<DeleteThirdProviderOneFileCommand>
    {
        private readonly IThirdProviderOneFileRepository _repository;

        public DeleteThirdProviderOneFileCommandHandler(IThirdProviderOneFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteThirdProviderOneFileCommand request, CancellationToken cancellationToken)
        {
            var deletedProduct = await _repository.GetProductById(request.ProductId);
            
            await _repository.Delete(deletedProduct);

            return Unit.Value;
        }
    }
}
