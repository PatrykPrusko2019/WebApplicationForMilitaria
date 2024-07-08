
using MediatR;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.CreatePhotoCategoryModal
{
    public class CreatePhotoCategoryCommand : PhotoCategoryDto, IRequest
    {
        public int ProductId { get; set; }

    }
}
