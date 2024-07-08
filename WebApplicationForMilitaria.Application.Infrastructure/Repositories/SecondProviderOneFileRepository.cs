
using Microsoft.EntityFrameworkCore;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileOne;
using WebApplicationForMilitaria.Domain.Interfaces;
using WebApplicationForMilitaria.Infrastructure.Persistance;

namespace WebApplicationForMilitaria.Infrastructure.Repositories
{
    public class SecondProviderOneFileRepository : ISecondProviderOneFileRepository
    {
        private readonly WebAppDbContext _dbContext;

        public SecondProviderOneFileRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        => await _dbContext.SaveChangesAsync();

        public async Task Create(Product product)
        {
            _dbContext.Products2.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Product deletedProduct)
        {
            _dbContext.Products2.Remove(deletedProduct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        => await _dbContext.Products2.ToListAsync();

        public async Task<Product> GetProductById(int id)
        => await _dbContext.Products2.FirstOrDefaultAsync(x => x.Id == id);

        public async Task SaveToDatabase(Products products)
        {
            foreach (var product in products.ProductList)
            {
                product.ProductIdFromXML = product.Id;
                product.Id = default;
                _dbContext.Products2.Add(product);
            }

            await _dbContext.SaveChangesAsync();
        }


    }
}
