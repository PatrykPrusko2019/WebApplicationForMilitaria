
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Domain.Entities.JsonFIle;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.JsonFile.Commands.CreateJsonFile
{
    public class CreateJsonFileCommandHandler : IRequestHandler<CreateJsonFileCommand>
    {
        private readonly IJsonFileRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateJsonFileCommandHandler(IJsonFileRepository repository, IMapper mapper, IUserContext userContext)
        {
            _repository = repository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateJsonFileCommand request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<BillingEntry>(request);

            record.CreatedById = _userContext.GetCurrentUser()!.Id;
            if (record.CreatedById == null) record.CreatedById = "";
            if (record.BillingEntryIdJson == null) record.BillingEntryIdJson = "";

            await _repository.Create(record);

            return Unit.Value;
        }

    }
}
