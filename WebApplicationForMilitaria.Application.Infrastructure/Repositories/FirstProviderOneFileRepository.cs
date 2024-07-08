
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne;
using WebApplicationForMilitaria.Domain.Interfaces;
using WebApplicationForMilitaria.Infrastructure.Persistance;

namespace WebApplicationForMilitaria.Infrastructure.Repositories
{
    public class FirstProviderOneFileRepository : IFirstProviderOneFileRepository
    {
        private readonly WebAppDbContext _dbContext;

        public FirstProviderOneFileRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        => await _dbContext.SaveChangesAsync();

        public async Task Create(Product product)
        {
            Offer offer = new Offer()
            {
                Products = new Products()
                {
                    ProductList = new List<Product>()
                {
                    product
                }
                }
            };

            _dbContext.Offers2.Add(offer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Product deletedProduct)
        {
            _dbContext.Products.Remove(deletedProduct);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            IEnumerable<Product> products = await _dbContext.Products.Include(p => p.Products).ToListAsync();
            
            for (int i = 0; i < products.Count(); i ++)
            {
                var product = products.ElementAt(i);

                if (product == null) continue;

                product.Price = _dbContext.Prices.FirstOrDefault(p => p.ProductId == product.ProductId);
                product.Srp = _dbContext.Srps.FirstOrDefault(s => s.ProductId == product.ProductId);
                var _size = _dbContext.SizesSet.FirstOrDefault(s => s.ProductId == product.ProductId);
                if (_size != null)
                {
                    int idSize = _dbContext.SizesSet.FirstOrDefault(s => s.ProductId == product.ProductId).SizesId;
                    product.Sizes.SizeList = _dbContext.SizeList.Where(s => s.SizeId == idSize).ToList();
                    for (int j = 0; j < product.Sizes.SizeList.Count(); j++)
                    {
                        var size = product.Sizes.SizeList[j];
                        size.Stock = _dbContext.Stocks.FirstOrDefault(s => s.SizeId == size.SizeId);
                    }
                }
                
            }

            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _dbContext.Products
            .Include(p => p.Price)
            .Include(s => s.Srp)
            .FirstOrDefaultAsync(e => e.ProductId == id);

            var sizes = await _dbContext.SizesSet
                .Include(s => s.SizeList)
                .FirstOrDefaultAsync(s => s.ProductId == id);

            if (sizes != null)
            {
                var stock = await _dbContext.Stocks
                .FirstOrDefaultAsync(s => s.SizeId == sizes.SizeList.FirstOrDefault().SizeId);
            }

            if (product == null) product = new Product();
            return product;
        }
        public async Task SaveToDatabase(Offer offer)
        {
            _dbContext.Offers2.Add(offer);
            await _dbContext.SaveChangesAsync();
        }


    }
}
