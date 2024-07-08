
using System.ComponentModel.DataAnnotations;

namespace WebApplicationForMilitaria.Domain.FirstProviderFileTwoXML
{
    public class Parameter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
