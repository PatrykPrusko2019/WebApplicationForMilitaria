
using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Application.JsonFile.DtosJsons;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.JsonFile.Queries.GetRecordByIdJsonFile
{
    public class GetRecordByIdJsonFileQueryHandler : IRequestHandler<GetRecordByIdJsonFileQuery, BillingEntryDto>
    {
        private readonly IJsonFileRepository _repository;
        private readonly IMapper _mapper;

        public GetRecordByIdJsonFileQueryHandler(IJsonFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BillingEntryDto> Handle(GetRecordByIdJsonFileQuery request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetRecordById(request.Id);

            var recordDto = _mapper.Map<BillingEntryDto>(record);

            return recordDto;
        }
    }
}
