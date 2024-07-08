
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileTwo;
using WebApplicationForMilitaria.Domain.SecondProviderFileTwoXML;

namespace WebApplicationForMilitaria.Domain.Interfaces
{
    public interface ISecondProviderTwoFileRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task SaveToDatabase(List<ProductXml> product);
        Task Commit();
        Task<Product> GetProductById(int id);
        Task Create(Product product);
        Task Delete(Product employee);
        Task DeleteCategories(ICollection<Category> categories);
        Task DeleteCategoryById(int categoryId);
        Task DeteleByIdPhoto(int photoId);
    }
}
