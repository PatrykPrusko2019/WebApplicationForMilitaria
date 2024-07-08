
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationForMilitaria.Domain.Entities.JsonFIle
{
    public class Balance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BalanceId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
