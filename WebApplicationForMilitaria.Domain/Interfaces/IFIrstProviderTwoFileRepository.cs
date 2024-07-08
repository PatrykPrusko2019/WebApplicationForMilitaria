

using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileTwo;

namespace WebApplicationForMilitaria.Domain.Interfaces
{
    public interface IFIrstProviderTwoFileRepository
    {
        Task<IEnumerable<Entities.FirstProviderFileTwo.Product>> GetAll();
        Task SaveToDatabase(IEnumerable<Domain.FirstProviderFileTwoXML.Product> productsXml);

        Task Create(Entities.FirstProviderFileTwo.Product product);
        Task<Entities.FirstProviderFileTwo.Product> GetProductById(int id);
        Task Delete(Product deletedRecord);
    }
}
