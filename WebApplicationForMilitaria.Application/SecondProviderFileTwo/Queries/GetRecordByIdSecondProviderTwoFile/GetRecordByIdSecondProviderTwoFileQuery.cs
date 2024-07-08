using MediatR;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Queries.GetRecordByIdSecondProviderTwoFile
{
    public class GetRecordByIdSecondProviderTwoFileQuery : IRequest<ProductFourDto>
    {
        public int Id { get; set; }

        public GetRecordByIdSecondProviderTwoFileQuery(int id)
        {
            Id = id;
        }
    }
}
