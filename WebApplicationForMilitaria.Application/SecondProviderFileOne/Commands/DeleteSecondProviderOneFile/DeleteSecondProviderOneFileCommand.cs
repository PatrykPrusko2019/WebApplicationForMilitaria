
using MediatR;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileOne;

namespace WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.DeleteSecondProviderOneFile
{
    public class DeleteSecondProviderOneFileCommand : Product, IRequest
    {
        public DeleteSecondProviderOneFileCommand(int id)
        {
            Id = id;
        }
    }
}
