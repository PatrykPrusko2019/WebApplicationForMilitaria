
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Application.SecondProviderFileOne
{
    public class ProductThreeDto
    {
        public int Id { get; set; }
        public string Ean { get; set; }

        public string Sku { get; set; }
        public string InStock { get; set; }

        public int Qty { get; set; }

        public string Availability { get; set; }

        public int ProductIdFromXML { get; set; }

        public string? CreatedById { get; set; }

        public bool IsEditable { get; set; }
    }
}
