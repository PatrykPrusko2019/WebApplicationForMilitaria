using OpenQA.Selenium.DevTools.V126.IndexedDB;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationForMilitaria.Domain.JsonFileToObject
{
    public class BillingEntry
    {
        
        public string Id { get; set; }

        public DateTime OccurredAt { get; set; }

        public int TypeId { get; set; }
        public Type Type { get; set; } = default!;

        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public int ValueId { get; set; }
        public Value Value { get; set; } = default!;

        public int TaxId { get; set; }
        public Tax Tax { get; set; } = default!;

        public int BalanceId { get; set; }
        public Balance Balance { get; set; } = default!;

        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;
    }
}
