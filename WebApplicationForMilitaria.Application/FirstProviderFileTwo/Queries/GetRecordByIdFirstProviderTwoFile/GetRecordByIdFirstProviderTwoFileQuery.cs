
using MediatR;

namespace WebApplicationForMilitaria.Application.FirstProviderFileTwo.Queries.GetRecordByIdFirstProviderTwoFile
{
    public class GetRecordByIdFirstProviderTwoFileQuery : IRequest<ProductTwoDto>
    {

        public int Id { get; set; }

        public GetRecordByIdFirstProviderTwoFileQuery(int id)
        {
            Id = id;
        }
    }
}
