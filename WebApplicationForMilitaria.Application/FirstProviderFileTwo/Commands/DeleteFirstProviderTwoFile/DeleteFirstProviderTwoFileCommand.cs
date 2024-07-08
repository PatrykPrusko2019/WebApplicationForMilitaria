
using MediatR;

namespace WebApplicationForMilitaria.Application.FirstProviderFileTwo.Commands.DeleteFirstProviderTwoFile
{
    public class DeleteFirstProviderTwoFileCommand : ProductTwoDto, IRequest
    {
        public DeleteFirstProviderTwoFileCommand(int id)
        {
            Id = id;
        }
    }
}
