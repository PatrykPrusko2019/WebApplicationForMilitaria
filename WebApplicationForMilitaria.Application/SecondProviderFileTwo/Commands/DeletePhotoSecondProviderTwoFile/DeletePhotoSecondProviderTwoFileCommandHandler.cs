
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.DeletePhotoSecondProviderTwoFile
{
    public class DeletePhotoSecondProviderTwoFileCommandHandler : IRequestHandler<DeletePhotoSecondProviderTwoFileCommand>
    {
        private readonly ISecondProviderTwoFileRepository _repository;

        public DeletePhotoSecondProviderTwoFileCommandHandler(ISecondProviderTwoFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePhotoSecondProviderTwoFileCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeteleByIdPhoto(request.PhotoId);

            return Unit.Value;
        }
    }
}
