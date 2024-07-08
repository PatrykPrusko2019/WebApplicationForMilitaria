
using System.ComponentModel.DataAnnotations;

namespace WebApplicationForMilitaria.Domain.Entities.FirstProviderFileTwo
{
    public class Icon
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
