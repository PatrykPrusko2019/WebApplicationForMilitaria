
using WebApplicationForMilitaria.Domain.Entities.JsonFIle;

namespace WebApplicationForMilitaria.Application.JsonFile.DtosJsons
{
    public class BillingEntryDto
    {
        public string Id { get; set; }
        public DateTime OccurredAt { get; set; }
        public Domain.Entities.JsonFIle.Type Type { get; set; } = default!;
        public Offer Offer { get; set; } = default!;
        public Value Value { get; set; } = default!;
        public Tax Tax { get; set; } = default!;
        public Balance Balance { get; set; } = default!;
        public Order Order { get; set; } = default!;

        public string? CreatedById { get; set; }

        public bool IsEditable { get; set; }
    }
}
