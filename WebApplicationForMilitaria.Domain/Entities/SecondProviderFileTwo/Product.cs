
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Identity;

namespace WebApplicationForMilitaria.Domain.Entities.SecondProviderFileTwo
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public ICollection<Category> Categories { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

        public bool IsEditable { get; set; }
    }
}
