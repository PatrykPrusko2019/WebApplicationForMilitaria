
using Microsoft.AspNetCore.Identity;
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileTwo;

namespace WebApplicationForMilitaria.Application.FirstProviderFileTwo
{
    public class ProductTwoDto
    {
        public int Id { get; set; }
        public int ProductIdXML { get; set; }
        public string ProducerId { get; set; }
        public string CategoryId { get; set; }
        public string UnitId { get; set; }
        public string WarrantyId { get; set; }
        public string CardUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceNet { get; set; }
        public decimal PriceGross { get; set; }
        public decimal SrvNet { get; set; }
        public decimal SrvGross { get; set; }

        public ICollection<Image> Images { get; set; }
        public ICollection<Icon> Icons { get; set; }
        public ICollection<Size> Sizes { get; set; }
        public ICollection<Parameter> Parameters { get; set; }

        public string? CreatedById { get; set; }

        public bool IsEditable { get; set; }
    }
}
