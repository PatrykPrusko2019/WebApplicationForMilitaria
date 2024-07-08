
using MediatR;
using WebApplicationForMilitaria.Domain.Entities.ThirdProviderFileOne;

namespace WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.DeleteThirdProviderOneFile
{
    public class DeleteThirdProviderOneFileCommand : Product, IRequest
    {
        public DeleteThirdProviderOneFileCommand(int id)
        {
            ProductId = id;
        }
    }
}
