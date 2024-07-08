
using MediatR;
using WebApplicationForMilitaria.Application.JsonFile.DtosJsons;

namespace WebApplicationForMilitaria.Application.JsonFile.Queries.GetRecordByIdJsonFile
{
    public class GetRecordByIdJsonFileQuery : IRequest<BillingEntryDto>
    {
        public int Id { get; set; }

        public GetRecordByIdJsonFileQuery(int id)
        {
            Id = id;
        }
    }
}
