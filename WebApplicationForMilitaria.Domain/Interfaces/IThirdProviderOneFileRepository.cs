
using WebApplicationForMilitaria.Domain.Entities.ThirdProviderFileOne;
using WebApplicationForMilitaria.Domain.ThirdProviderFileOneXML;

namespace WebApplicationForMilitaria.Domain.Interfaces
{
    public interface IThirdProviderOneFileRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task SaveToDatabase(List<ProductXml> product);

        Task Create(Product product);
        Task<Product> GetProductById(int id);
        Task Delete(Product deletedProduct);
        Task Commit();
    }
}

