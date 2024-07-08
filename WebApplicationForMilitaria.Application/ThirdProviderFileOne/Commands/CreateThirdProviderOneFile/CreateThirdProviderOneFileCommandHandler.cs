
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Domain.Entities.ThirdProviderFileOne;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.CreateThirdProviderOneFile
{
    public class CreateThirdProviderOneFileCommandHandler : IRequestHandler<CreateThirdProviderOneFileCommand>
    {
        private readonly IThirdProviderOneFileRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateThirdProviderOneFileCommandHandler(IThirdProviderOneFileRepository repository, IMapper mapper, IUserContext userContext)
        {
            _repository = repository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateThirdProviderOneFileCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            product.CreatedById = _userContext.GetCurrentUser()!.Id;

            await _repository.Create(product);

            return Unit.Value;
        }

    }
}
