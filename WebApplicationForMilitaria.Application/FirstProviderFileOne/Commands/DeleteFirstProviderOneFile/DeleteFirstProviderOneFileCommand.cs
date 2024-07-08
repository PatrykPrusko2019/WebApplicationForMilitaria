
using MediatR;
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne;

namespace WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.DeleteFirstProviderOneFile
{
    public class DeleteFirstProviderOneFileCommand : Product, IRequest
    {
        public DeleteFirstProviderOneFileCommand(int id)
        {
            ProductId = id;
        }
    }
}
