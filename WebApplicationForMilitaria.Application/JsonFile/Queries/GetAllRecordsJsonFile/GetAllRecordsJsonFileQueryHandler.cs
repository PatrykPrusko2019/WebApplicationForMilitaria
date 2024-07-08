
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Application.FirstProviderFileOne;
using WebApplicationForMilitaria.Application.JsonFile.DtosJsons;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.JsonFile.Queries.GetAllRecordsJsonFile
{
    public class GetAllRecordsJsonFileQueryHandler : IRequestHandler<GetAllRecordsJsonFileQuery, IEnumerable<BillingEntryDto>>
    {
        private readonly IJsonFileRepository _repository;
        private readonly IMapper _mapper;

        public GetAllRecordsJsonFileQueryHandler(IJsonFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BillingEntryDto>> Handle(GetAllRecordsJsonFileQuery request, CancellationToken cancellationToken)
        {
            var billingsEntries = await _repository.GetAll();
            var billingsEntriesDtos = _mapper.Map<IEnumerable<BillingEntryDto>>(billingsEntries);

            return billingsEntriesDtos;
        }
    }
}
