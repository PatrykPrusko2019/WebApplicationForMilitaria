
using System.Text;
using WebApplicationForMilitaria.Domain.Entities.JsonFIle;
using WebApplicationForMilitaria.Domain.JsonList;

namespace WebApplicationForMilitaria.Domain.Interfaces
{
    public interface IJsonFileRepository
    {
        Task<IEnumerable<BillingEntry>> GetAll();
        Task SaveToDatabase(BillingEntriesWrapper billingEntriesWrapper);

        Task Create(BillingEntry billingEntry);
        Task<BillingEntry> GetRecordById(int id);
        Task Commit();
        Task Delete(BillingEntry deletedRecord);

        Task<string> GetAllAPIAllegro(StringBuilder token);
    }
}
