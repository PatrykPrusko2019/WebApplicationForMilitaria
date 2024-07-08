
using MediatR;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileTwo;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.DeleteCategorySecondProviderTwoFile
{
    public class DeleteCategorySecondProviderTwoFileCommand : Category, IRequest
    {
        public DeleteCategorySecondProviderTwoFileCommand(int id)
        {
            CategoryId = id;
        }
    }
}
