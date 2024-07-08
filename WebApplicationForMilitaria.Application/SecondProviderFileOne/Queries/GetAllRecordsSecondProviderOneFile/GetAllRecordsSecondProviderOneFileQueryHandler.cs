
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileOne.Queries.GetAllRecordsSecondProviderOneFile
{
    public class GetAllRecordsSecondProviderOneFileQueryHandler : IRequestHandler<GetAllRecordsSecondProviderOneFileQuery, IEnumerable<ProductThreeDto>>
    {
        private readonly ISecondProviderOneFileRepository _repository;
        private readonly IMapper _mapper;

        public GetAllRecordsSecondProviderOneFileQueryHandler(ISecondProviderOneFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductThreeDto>> Handle(GetAllRecordsSecondProviderOneFileQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAll();
            var productsDtos = _mapper.Map<IEnumerable<ProductThreeDto>>(products);

            return productsDtos;
        }
    }
}
