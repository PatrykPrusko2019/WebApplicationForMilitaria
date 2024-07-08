
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileOne;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.CreateSecondProviderOneFile
{
    public class CreateSecondProviderOneFileCommandHandler : IRequestHandler<CreateSecondProviderOneFileCommand>
    {
        private readonly ISecondProviderOneFileRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateSecondProviderOneFileCommandHandler(ISecondProviderOneFileRepository repository, IMapper mapper, IUserContext userContext)
        {
            _repository = repository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateSecondProviderOneFileCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            product.CreatedById = _userContext.GetCurrentUser()!.Id;

            await _repository.Create(product);

            return Unit.Value;
        }
    }
}
