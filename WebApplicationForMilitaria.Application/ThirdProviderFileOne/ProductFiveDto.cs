
namespace WebApplicationForMilitaria.Application.ThirdProviderFileOne
{
    public class ProductFiveDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public string NamePl { get; set; }

        public string NameEn { get; set; }

        public string Description { get; set; }

        public string DescriptionPl { get; set; }

        public string DescriptionEn { get; set; }

        public string Code { get; set; }

        public string Ean { get; set; }

        public int Status { get; set; }

        public decimal WholesalePrice { get; set; }

        public decimal SuggestedPrice { get; set; }

        public string SupplierCode { get; set; }

        public decimal Vat { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public string Category { get; set; }

        public string CategoryPl { get; set; }

        public string CategoryEn { get; set; }

        public ICollection<PhotoFiveDto> Photos { get; set; } = new List<PhotoFiveDto>();

        public bool IsEditable { get; set; }
    }
}
