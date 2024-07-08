
using MediatR;

namespace WebApplicationForMilitaria.Application.FirstProviderFileOne.Queries.GetProductByIdFirstProviderOneFile
{
    public class GetProductByIdFirstProviderOneFileQuery : IRequest<ProductOneDto>
    {
        public int Id { get; set; }

        public GetProductByIdFirstProviderOneFileQuery(int id)
        {
            Id = id;
        }
    }
}
