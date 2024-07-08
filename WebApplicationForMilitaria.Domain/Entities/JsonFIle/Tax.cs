
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationForMilitaria.Domain.Entities.JsonFIle
{
    public class Tax
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaxId { get; set; }
        public decimal Percentage { get; set; }
    }
}
