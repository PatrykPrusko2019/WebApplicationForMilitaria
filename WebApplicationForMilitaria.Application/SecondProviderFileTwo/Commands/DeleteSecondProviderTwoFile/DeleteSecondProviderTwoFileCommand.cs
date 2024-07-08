
using MediatR;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileTwo;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.DeleteSecondProviderTwoFile
{
    public class DeleteSecondProviderTwoFileCommand : Product, IRequest
    {
        public DeleteSecondProviderTwoFileCommand(int id)
        {
            ProductId = id;
        }
    }
}
