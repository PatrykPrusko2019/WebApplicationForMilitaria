
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileTwo;
using WebApplicationForMilitaria.Domain.Interfaces;
using WebApplicationForMilitaria.Domain.SecondProviderFileTwoXML;
using WebApplicationForMilitaria.Infrastructure.Persistance;

namespace WebApplicationForMilitaria.Infrastructure.Repositories
{
    public class SecondProviderTwoFileRepository : ISecondProviderTwoFileRepository
    {
        private readonly WebAppDbContext _dbContext;

        public SecondProviderTwoFileRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Product product)
        {
            _dbContext.Products3.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Commit()
        => await _dbContext.SaveChangesAsync();

        public async Task<IEnumerable<Product>> GetAll()
        => await _dbContext.Products3
            .Include(p => p.Photos)
            .Include(c => c.Categories)
            .ToListAsync();

        public async Task<Product> GetProductById(int id)
        {
            var product = await _dbContext.Products3
           .Include(p => p.Photos)
           .Include(c => c.Categories)
           .FirstAsync(p => p.ProductId == id);

            var photos = await _dbContext.Photos.Where(p => p.ProductId == id).ToListAsync();
            product.Photos = photos;
            return product;
        }

        public async Task SaveToDatabase(List<ProductXml> productsXml)
        {
            foreach (var productXml in productsXml)
            {
                var product = new Product
                {
                    Ean = productXml.Ean,
                    Sku = productXml.Sku,
                    Name = productXml.Name,
                    Desc = productXml.Desc,
                    Url = productXml.Url,
                    Unit = productXml.Unit,
                    Weight = productXml.Weight,
                    PKWiU = productXml.PKWiU,
                    InStock = productXml.InStock,
                    Qty = productXml.Qty,
                    RequiredBox = productXml.RequiredBox,
                    QuantityPerBox = productXml.QuantityPerBox,
                    PriceAfterDiscountNet = productXml.PriceAfterDiscountNet,
                    Vat = productXml.Vat,
                    RetailPriceGross = productXml.RetailPriceGross,
                    Categories = new List<Category>(),
                    Photos = productXml.Photos.Select(p => new Photo
                    {
                        Url = p.Url,
                        IsMain = p.IsMain
                    }).ToList()
                };

                foreach (var categoryXml in productXml.Categories)
                {
                    var category = _dbContext.Categories
                        .FirstOrDefault(c => c.Name == categoryXml.Name);

                    if (category == null)
                    {
                        category = new Category { Name = categoryXml.Name };
                        category.CategoryIdXML = categoryXml.CategoryIdXML;
                        _dbContext.Categories.Add(category);
                    }

                    product.Categories.Add(category);
                }
                _dbContext.Products3.Add(product);
            }
                await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Product employee)
        {
            _dbContext.Products3.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategories(ICollection<Category> categories)
        {
            _dbContext.Categories.RemoveRange(categories);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryById(int categoryId)
        {
            var removedCategory = _dbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);

            _dbContext.Categories.Remove(removedCategory);
            
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeteleByIdPhoto(int photoId)
        {
            var removedPhoto = _dbContext.Photos.FirstOrDefault(c => c.PhotoId == photoId);
            _dbContext.Photos.Remove(removedPhoto);
            await _dbContext.SaveChangesAsync();
        }
    }
}
