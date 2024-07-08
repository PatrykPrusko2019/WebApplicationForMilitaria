
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo;
using WebApplicationForMilitaria.Domain.Interfaces;
namespace WebApplicationForMilitaria.Application.ThirdProviderFileOne.Queries.GetRecordByIdThirdProviderOneFile
{
    public class GetRecordByIdThirdProviderOneFileQueryHandler : IRequestHandler<GetRecordByIdThirdProviderOneFileQuery, ProductFiveDto>
    {
        private readonly IThirdProviderOneFileRepository _repository;
        private readonly IMapper _mapper;

        public GetRecordByIdThirdProviderOneFileQueryHandler(IThirdProviderOneFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductFiveDto> Handle(GetRecordByIdThirdProviderOneFileQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);

            var productDto = _mapper.Map<ProductFiveDto>(product);

            return productDto;
        }
    }
}
