using Microsoft.AspNetCore.Identity;
using OpenQA.Selenium.DevTools.V126.IndexedDB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationForMilitaria.Domain.Entities.JsonFIle
{
    public class BillingEntry
    {
        [Key]
        public int Id { get; set; }

        public string BillingEntryIdJson { get; set; } = default!;
        public DateTime OccurredAt { get; set; }

        public int TypeId { get; set; }
        public Type Type { get; set; } = default!;

        public int OfferId { get; set; }
        public Offer Offer { get; set; } = default!;

        public int ValueId { get; set; }
        public Value Value { get; set; } = default!;

        public int TaxId { get; set; }
        public Tax Tax { get; set; } = default!;

        public int BalanceId { get; set; }
        public Balance Balance { get; set; } = default!;

        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;

        public string? CreatedById { get; set; } = default!;
        public IdentityUser? CreatedBy { get; set; }

        public bool IsEditable { get; set; }
    }
}
