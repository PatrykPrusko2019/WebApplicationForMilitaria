
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationForMilitaria.Domain.Entities.SecondProviderFileTwo
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        public string Name { get; set; } = default!;

        public ICollection<Product> Products { get; set; } = default!;
        public string CategoryIdXML { get; set; } = default!;
    }
}
