
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.DeleteCategorySecondProviderTwoFile
{
    public class DeleteCategorySecondProviderTwoFileCommandHandler : IRequestHandler<DeleteCategorySecondProviderTwoFileCommand>
    {
        private readonly ISecondProviderTwoFileRepository _repository;

        public DeleteCategorySecondProviderTwoFileCommandHandler(ISecondProviderTwoFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategorySecondProviderTwoFileCommand request, CancellationToken cancellationToken)
        {
             await _repository.DeleteCategoryById(request.CategoryId);

            return Unit.Value;
        }
    }
}
