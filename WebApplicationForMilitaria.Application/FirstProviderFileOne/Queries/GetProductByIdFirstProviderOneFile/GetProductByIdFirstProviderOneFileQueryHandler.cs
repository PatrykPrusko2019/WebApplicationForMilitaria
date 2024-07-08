
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.FirstProviderFileOne.Queries.GetProductByIdFirstProviderOneFile
{
    public class GetProductByIdFirstProviderOneFileQueryHandler : IRequestHandler<GetProductByIdFirstProviderOneFileQuery, ProductOneDto>
    {
        private readonly IFirstProviderOneFileRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdFirstProviderOneFileQueryHandler(IFirstProviderOneFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductOneDto> Handle(GetProductByIdFirstProviderOneFileQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);

            var productDto = _mapper.Map<ProductOneDto>(product);

            try
            {
                if (product != null && product.Sizes != null)
                {
                    productDto.Size = product.Sizes.SizeList.FirstOrDefault();
                    productDto.Stock = product.Sizes.SizeList.FirstOrDefault().Stock;
                }
            }
            catch (Exception ex) 
            {
                
            }
            finally{
                productDto.Size = new Domain.Entities.FirstProviderFileOne.Size();
                productDto.Stock = new Domain.Entities.FirstProviderFileOne.Stock();
                productDto.Sizes = new Domain.Entities.FirstProviderFileOne.Sizes(); 
            }
            
            return productDto;
        }
    }
}
