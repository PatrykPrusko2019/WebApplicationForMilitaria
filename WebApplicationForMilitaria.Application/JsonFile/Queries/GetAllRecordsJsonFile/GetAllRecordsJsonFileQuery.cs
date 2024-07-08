
using MediatR;
using WebApplicationForMilitaria.Application.JsonFile.DtosJsons;

namespace WebApplicationForMilitaria.Application.JsonFile.Queries.GetAllRecordsJsonFile
{
    public class GetAllRecordsJsonFileQuery : IRequest<IEnumerable<BillingEntryDto>>
    {
    }
}
