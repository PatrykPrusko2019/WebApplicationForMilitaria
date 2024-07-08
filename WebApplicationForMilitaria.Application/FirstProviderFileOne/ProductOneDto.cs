
using Microsoft.AspNetCore.Identity;
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne;

namespace WebApplicationForMilitaria.Application.FirstProviderFileOne
{
    public class ProductOneDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Price Price { get; set; }
        public Srp Srp { get; set; }
        public Sizes Sizes { get; set; }

        public Size Size { get; set; }

        public Stock Stock { get; set; }

        public string? CreatedById { get; set; }

        public bool IsEditable { get; set; }
    }
}
