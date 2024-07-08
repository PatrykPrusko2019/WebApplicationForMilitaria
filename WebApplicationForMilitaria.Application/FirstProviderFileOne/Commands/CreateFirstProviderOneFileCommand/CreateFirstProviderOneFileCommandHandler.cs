
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.CreateFirstProviderOneFileCommand
{
    public class CreateFirstProviderOneFileCommandHandler : IRequestHandler<CreateFirstProviderOneFileCommand>
    {
        private readonly IFirstProviderOneFileRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateFirstProviderOneFileCommandHandler(IFirstProviderOneFileRepository repository, IMapper mapper, IUserContext userContext)
        {
            _repository = repository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateFirstProviderOneFileCommand request, CancellationToken cancellationToken)
        {
            request.Size.CodeProducer = "";
            request.Size.Code = "";
            var product = _mapper.Map<Product>(request);
            product.CreatedById = _userContext.GetCurrentUser()!.Id;
            if (product.CreatedById == null) product.CreatedById = "";


            await _repository.Create(product);

            return Unit.Value;

        }
    }
}
