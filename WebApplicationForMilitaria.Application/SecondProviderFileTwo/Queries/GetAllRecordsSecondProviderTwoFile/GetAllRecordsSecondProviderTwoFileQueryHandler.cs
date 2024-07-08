
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Queries.GetAllRecordsSecondProviderTwoFile
{
    public class GetAllRecordsSecondProviderTwoFileQueryHandler : IRequestHandler<GetAllRecordsSecondProviderTwoFileQuery, IEnumerable<ProductFourDto>>
    {
        private readonly ISecondProviderTwoFileRepository _repository;
        private readonly IMapper _mapper;

        public GetAllRecordsSecondProviderTwoFileQueryHandler(ISecondProviderTwoFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductFourDto>> Handle(GetAllRecordsSecondProviderTwoFileQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAll();
            var productsDtos = _mapper.Map<IEnumerable<ProductFourDto>>(products);

            return productsDtos;
        }
    }
}
