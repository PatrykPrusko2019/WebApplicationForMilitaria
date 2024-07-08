
using MediatR;
using AutoMapper;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Queries.GetRecordByIdSecondProviderTwoFile
{
    public class GetRecordByIdSecondProviderTwoFileQueryHandler : IRequestHandler<GetRecordByIdSecondProviderTwoFileQuery, ProductFourDto>
    {
        private readonly ISecondProviderTwoFileRepository _repository;
        private readonly IMapper _mapper;

        public GetRecordByIdSecondProviderTwoFileQueryHandler(ISecondProviderTwoFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductFourDto> Handle(GetRecordByIdSecondProviderTwoFileQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);

            var productDto = _mapper.Map<ProductFourDto>(product);
            var photoDto = _mapper.Map<List<PhotoFourDto>>(product.Photos);
            productDto.Photo = photoDto;

            return productDto;
        }
    }
}
