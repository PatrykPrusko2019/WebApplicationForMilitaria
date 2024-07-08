

using MediatR;

namespace WebApplicationForMilitaria.Application.ThirdProviderFileOne.Queries.GetRecordByIdThirdProviderOneFile
{
    public class GetRecordByIdThirdProviderOneFileQuery : IRequest<ProductFiveDto>
    {
        public int Id { get; set; }

        public GetRecordByIdThirdProviderOneFileQuery(int id)
        {
            Id = id;
        }
    }
}
