
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileTwo;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.FirstProviderFileTwo.Commands.CreateFirstProviderTwoFile
{
    public class CreateFirstProviderTwoFileCommandHandler : IRequestHandler<CreateFirstProviderTwoFileCommand>
    {
        private readonly IFIrstProviderTwoFileRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateFirstProviderTwoFileCommandHandler(IFIrstProviderTwoFileRepository repository, IMapper mapper, IUserContext userContext)
        {
            _repository = repository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateFirstProviderTwoFileCommand request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Product>(request);

            record.CreatedById = _userContext.GetCurrentUser()!.Id;
            if (record.CreatedById == null) record.CreatedById = "";
            record.Parameters = new List<Parameter>();
            record.Icons = new List<Icon>();
            record.Sizes = new List<Size>();
            record.Images = new List<Image>();
            

            await _repository.Create(record);

            return Unit.Value;
        }
    }
}
