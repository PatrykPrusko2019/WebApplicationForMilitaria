
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.JsonFile.Commands.DeleteJsonFile
{
    public class DeleteJsonFileCommandHandler : IRequestHandler<DeleteJsonFileCommand>
    {
        private readonly IJsonFileRepository _repository;

        public DeleteJsonFileCommandHandler(IJsonFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteJsonFileCommand request, CancellationToken cancellationToken)
        {
            var deletedRecord = await _repository.GetRecordById(request.Id);

            await _repository.Delete(deletedRecord);

            return Unit.Value;
        }
    }
}
