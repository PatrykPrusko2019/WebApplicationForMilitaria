
using Microsoft.EntityFrameworkCore;
using WebApplicationForMilitaria.Domain.Entities.ThirdProviderFileOne;
using WebApplicationForMilitaria.Domain.Interfaces;
using WebApplicationForMilitaria.Domain.ThirdProviderFileOneXML;
using WebApplicationForMilitaria.Infrastructure.Persistance;

namespace WebApplicationForMilitaria.Infrastructure.Repositories
{
    public class ThirdProviderOneFileRepository : IThirdProviderOneFileRepository
    {
        private readonly WebAppDbContext _dbContext;

        public ThirdProviderOneFileRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        => await _dbContext.SaveChangesAsync();

        public async Task Create(Product product)
        {
            _dbContext.Products4.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Product deletedProduct)
        {
            _dbContext.Products4.Remove(deletedProduct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        => await _dbContext.Products4
            .Include(p => p.Photos)
            .ToListAsync();

        public async Task<Product> GetProductById(int id)
        => await _dbContext.Products4.Include(p => p.Photos)
            .FirstAsync(p => p.ProductId == id);

        public async Task SaveToDatabase(List<ProductXml> productsXml)
        {
            foreach (var productXml in productsXml)
            {
                var product = new Product
                {
                    Name = productXml.Name,
                    NamePl = productXml.NamePl,
                    NameEn = productXml.NameEn,
                    Description = productXml.Description,
                    DescriptionPl = productXml.DescriptionPl,
                    DescriptionEn = productXml.DescriptionEn,
                    Code = productXml.Code,
                    Ean = productXml.Ean,
                    Status = productXml.Status,
                    WholesalePrice = productXml.WholesalePrice,
                    SuggestedPrice = productXml.SuggestedPrice,
                    SupplierCode = productXml.SupplierCode,
                    Vat = productXml.Vat,
                    Size = productXml.Size,
                    Color = productXml.Color,
                    Category = productXml.Category,
                    CategoryPl = productXml.CategoryPl,
                    CategoryEn = productXml.CategoryEn,
                    Photos = productXml.Photos.Select(p => new Photo
                    {
                        Url = p.Url
                    }).ToList()
                };

                _dbContext.Products4.Add(product);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
