
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileTwo;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.CreateSecondProviderTwoFile
{
    public class CreateSecondProviderTwoFileCommandHandler : IRequestHandler<CreateSecondProviderTwoFileCommand>
    {
        private readonly ISecondProviderTwoFileRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateSecondProviderTwoFileCommandHandler(ISecondProviderTwoFileRepository repository, IMapper mapper, IUserContext userContext)
        {
            _repository = repository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateSecondProviderTwoFileCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            product.CreatedById = _userContext.GetCurrentUser()!.Id;

            await _repository.Create(product);

            return Unit.Value;
        }
    }
}
