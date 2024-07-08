
using System.ComponentModel.DataAnnotations;

namespace WebApplicationForMilitaria.Domain.FirstProviderFileTwoXML
{
    public class Icon
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
