
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileOne;

namespace WebApplicationForMilitaria.Domain.Interfaces
{
    public interface ISecondProviderOneFileRepository
    {
        Task Commit();
        Task Create(Product product);
        Task Delete(Product deletedProduct); 
        Task <IEnumerable<Product>> GetAll();
        Task<Product> GetProductById(int id);
        Task SaveToDatabase(Products productXML);
    }
}
