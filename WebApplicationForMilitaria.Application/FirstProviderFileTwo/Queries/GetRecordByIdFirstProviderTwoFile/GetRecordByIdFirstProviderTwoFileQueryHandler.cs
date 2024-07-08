
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.FirstProviderFileTwo.Queries.GetRecordByIdFirstProviderTwoFile
{
    public class GetRecordByIdFirstProviderTwoFileQueryHandler : IRequestHandler<GetRecordByIdFirstProviderTwoFileQuery, ProductTwoDto>
    {
        private readonly IFIrstProviderTwoFileRepository _repository;
        private readonly IMapper _mapper;

        public GetRecordByIdFirstProviderTwoFileQueryHandler(IFIrstProviderTwoFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductTwoDto> Handle(GetRecordByIdFirstProviderTwoFileQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);

            var productDto = _mapper.Map<ProductTwoDto>(product);

            return productDto;
        }
    }
}
