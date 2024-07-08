
using MediatR;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileTwo;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.DeletePhotoSecondProviderTwoFile
{
    public class DeletePhotoSecondProviderTwoFileCommand : Photo, IRequest
    {
        public DeletePhotoSecondProviderTwoFileCommand(int id)
        {
            PhotoId = id;   
        }
    }
}
