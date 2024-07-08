
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileTwo;
using WebApplicationForMilitaria.Domain.Interfaces;
using WebApplicationForMilitaria.Infrastructure.Persistance;

namespace WebApplicationForMilitaria.Infrastructure.Repositories
{
    public class FIrstProviderTwoFileRepository : IFIrstProviderTwoFileRepository
    {
        private readonly WebAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public FIrstProviderTwoFileRepository(WebAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Create(Product product)
        {
            _dbContext.Products5.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Product deletedRecord)
        {
            _dbContext.Products5.Remove(deletedRecord);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        =>await _dbContext.Products5.ToListAsync();

        public async Task<Domain.Entities.FirstProviderFileTwo.Product> GetProductById(int id)
        => await _dbContext.Products5
            .Include(p => p.Icons)
            .Include(p => p.Images)
            .Include(p => p.Sizes)
            .Include(p => p.Parameters)
            .FirstAsync(p => p.Id == id);

        public async Task SaveToDatabase(IEnumerable<Domain.FirstProviderFileTwoXML.Product> productsXml)
        {
            var products = new List<Domain.Entities.FirstProviderFileTwo.Product>();

            foreach (var productElement in productsXml)
            {
                var product = new Domain.Entities.FirstProviderFileTwo.Product()
                {
                    ProductIdXML = productElement.Id,
                    ProducerId = productElement.ProducerId,
                    CategoryId = productElement.CategoryId,
                    UnitId = productElement.UnitId,
                    WarrantyId = productElement.WarrantyId,
                    CardUrl = productElement.CardUrl,
                    Name = productElement.Name,
                    Description = productElement.Description,
                    PriceNet = productElement.PriceNet,
                    PriceGross = productElement.PriceGross,
                    SrvNet = productElement.SrvNet,
                    SrvGross = productElement.SrvGross,

                };
                product.Images = new List<Domain.Entities.FirstProviderFileTwo.Image>();
                foreach (var image in productElement.Images)
                {
                    var recordImage = new Domain.Entities.FirstProviderFileTwo.Image() { Height = image.Height, Url = image.Url, Width = image.Width };
                    product.Images.Add(recordImage);
                }

                product.Icons = new List<Domain.Entities.FirstProviderFileTwo.Icon>();
                foreach (var icon in productElement.Icons)
                {
                    var recordIcon = new Domain.Entities.FirstProviderFileTwo.Icon()
                    {
                        Url = icon.Url,
                        Height = icon.Height,
                        Width = icon.Width
                    };
                    product.Icons.Add(recordIcon);
                }

                product.Sizes = new List<Domain.Entities.FirstProviderFileTwo.Size>();
                foreach (var size in productElement.Sizes)
                {
                    var recordSize = new Domain.Entities.FirstProviderFileTwo.Size()
                    {

                        CodeProducer = size.CodeProducer,
                        Code = size.Code,
                        PriceNet = size.PriceNet,
                        PriceGross = size.PriceGross,
                        SrvNet = size.SrvNet,
                        SrvGross = size.SrvGross,
                        StockId = size.StockId,
                        Quantity = size.Quantity
                    };
                    product.Sizes.Add(recordSize);

                }

                product.Parameters = new List<Domain.Entities.FirstProviderFileTwo.Parameter>();
                foreach (var parameter in productElement.Parameters)
                {
                    var recordParameter = new Domain.Entities.FirstProviderFileTwo.Parameter()
                    {
                        ParameterIdXML = parameter.Id,
                        Name = parameter.Name,
                        Value = parameter.Value
                    };
                    product.Parameters.Add(recordParameter);
                }

                products.Add(product);
            }


            _dbContext.Products5.AddRange(products);


            await _dbContext.SaveChangesAsync();
        }
    }
}
