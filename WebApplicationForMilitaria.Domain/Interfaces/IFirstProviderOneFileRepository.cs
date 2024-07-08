
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne;

namespace WebApplicationForMilitaria.Domain.Interfaces
{
    public interface IFirstProviderOneFileRepository
    {
        Task SaveToDatabase(Offer offer);

        Task<IEnumerable<Product>> GetAll();

        Task Create(Product product);
        Task<Product> GetProductById(int id);
        Task Commit();
        Task Delete(Product deletedProduct);
    }
}
