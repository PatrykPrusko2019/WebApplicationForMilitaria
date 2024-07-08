
using MediatR;

namespace WebApplicationForMilitaria.Application.SecondProviderFileOne.Queries.GetRecordByIdSecondProviderOneFile
{
    public class GetRecordByIdSecondProviderOneFileQuery : IRequest<ProductThreeDto>
    {
        public int Id { get; set; }

        public GetRecordByIdSecondProviderOneFileQuery(int id)
        {
            Id = id;
        }
    }
}
