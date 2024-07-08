
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.FirstProviderFileOne.Queries.GetAllRecords
{
    public class GetAllRecordsFirstProviderOneFileQueryHandler : IRequestHandler<GetAllRecordsFirstProviderOneFileQuery, IEnumerable<ProductOneDto>>
    {
        private readonly IFirstProviderOneFileRepository _repository;
        private readonly IMapper _mapper;

        public GetAllRecordsFirstProviderOneFileQueryHandler(IFirstProviderOneFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductOneDto>> Handle(GetAllRecordsFirstProviderOneFileQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAll();
            var productsDtos = _mapper.Map<IEnumerable<ProductOneDto>>(products);

            return productsDtos;
        }
    }
}
