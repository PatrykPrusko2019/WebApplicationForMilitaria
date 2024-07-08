
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.ThirdProviderFileOne.Queries.GetAllRecords
{
    public class GetAllRecordsThirdProviderOneFileQueryHandler : IRequestHandler<GetAllRecordsThirdProviderOneFileQuery, IEnumerable<ProductFiveDto>>
    {
        private readonly IThirdProviderOneFileRepository _repository;
        private readonly IMapper _mapper;

        public GetAllRecordsThirdProviderOneFileQueryHandler(IThirdProviderOneFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductFiveDto>> Handle(GetAllRecordsThirdProviderOneFileQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAll();
            var productsDtos = _mapper.Map<IEnumerable<ProductFiveDto>>(products);

            return productsDtos;
        }
    }
}
