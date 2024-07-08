
using Newtonsoft.Json;
using WebApplicationForMilitaria.Domain.JsonFileToObject;


namespace WebApplicationForMilitaria.Domain.JsonList
{
    public class BillingEntriesWrapper
    {
        [JsonProperty("billingEntries")]
        public List<BillingEntry> BillingEntries { get; set; }
    }
}
