
using System.ComponentModel.DataAnnotations;

namespace WebApplicationForMilitaria.Domain.Entities.FirstProviderFileTwo
{
    public class Parameter
    {
        [Key]
        public int Id { get; set; }
        public int ParameterIdXML { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
