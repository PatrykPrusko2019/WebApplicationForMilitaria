
namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo
{
    public class ProductFourDto
    {
        public int ProductId { get; set; }

        public string Ean { get; set; }

        public string Sku { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public string Url { get; set; }

        public string Unit { get; set; }

        public string Weight { get; set; }

        public string PKWiU { get; set; }

        public string InStock { get; set; }

        public int Qty { get; set; }

        public string RequiredBox { get; set; }

        public int QuantityPerBox { get; set; }

        public string PriceAfterDiscountNet { get; set; }

        public int Vat { get; set; }
        public decimal RetailPriceGross { get; set; }

        public List<CategoryFourDto> Categories { get; set; } = new List<CategoryFourDto>();

        public List<PhotoFourDto> Photo { get; set; } = new List<PhotoFourDto>();

        public string? CreatedById { get; set; }

        public bool IsEditable { get; set; }
    }
}
