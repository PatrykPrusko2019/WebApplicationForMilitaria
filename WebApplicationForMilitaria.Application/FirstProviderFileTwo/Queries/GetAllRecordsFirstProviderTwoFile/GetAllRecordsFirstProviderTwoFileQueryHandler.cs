
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Application.FirstProviderFileOne;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.FirstProviderFileTwo.Queries.GetAllRecordsFirstProviderTwoFile
{
    public class GetAllRecordsFirstProviderTwoFileQueryHandler : IRequestHandler<GetAllRecordsFirstProviderTwoFileQuery, IEnumerable<ProductTwoDto>>
    {
        private readonly IFIrstProviderTwoFileRepository _repository;
        private readonly IMapper _mapper;

        public GetAllRecordsFirstProviderTwoFileQueryHandler(IFIrstProviderTwoFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductTwoDto>> Handle(GetAllRecordsFirstProviderTwoFileQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAll();
            var productsDtos = _mapper.Map<IEnumerable<ProductTwoDto>>(products);

            return productsDtos;
        }
    }
}
