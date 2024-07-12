
using MediatR;
using System.Text;

namespace WebApplicationForMilitaria.Application.JsonFile.Queries.GetAllRecordsFromAPIAllegro
{
    public class GetAllRecordsFromAPIAllegroQuery : IRequest<StringBuilder>
    {
        public StringBuilder Token { get; set; }

        public GetAllRecordsFromAPIAllegroQuery(StringBuilder token)
        {
            Token = token;
        }
    }
}
