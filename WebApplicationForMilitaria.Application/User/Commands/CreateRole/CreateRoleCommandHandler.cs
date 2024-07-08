
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.User.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleUserCommand>
    {
        private readonly IUserRepository _repository;

        public CreateRoleCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateRoleUserCommand request, CancellationToken cancellationToken)
        {
           await _repository.CreateRole();

            return Unit.Value;
        }
    }
}
