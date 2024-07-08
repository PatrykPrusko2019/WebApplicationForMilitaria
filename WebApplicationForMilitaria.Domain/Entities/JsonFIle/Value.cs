
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationForMilitaria.Domain.Entities.JsonFIle
{
    public class Value
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ValueId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
