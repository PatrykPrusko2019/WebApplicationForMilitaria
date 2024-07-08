using MediatR;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileTwo;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.DeleteSecondProviderTwoFile
{
    public class DeleteSecondProviderTwoFileCommandHandler : IRequestHandler<DeleteSecondProviderTwoFileCommand>
    {
        private readonly ISecondProviderTwoFileRepository _repository;

        public DeleteSecondProviderTwoFileCommandHandler(ISecondProviderTwoFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteSecondProviderTwoFileCommand request, CancellationToken cancellationToken)
        {
            var deletedProduct = await _repository.GetProductById(request.ProductId);
            var deletedCategories = default(List<Category>);

            if (deletedProduct.Categories != null || deletedProduct.Categories.Count() > 0) deletedCategories = deletedProduct.Categories.ToList();

            await _repository.Delete(deletedProduct);

            if (deletedCategories != null) await _repository.DeleteCategories(deletedCategories);

            return Unit.Value;
        }
    }
}
