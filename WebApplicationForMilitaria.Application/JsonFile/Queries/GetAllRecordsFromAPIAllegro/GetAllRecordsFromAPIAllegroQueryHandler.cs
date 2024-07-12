
using AutoMapper;
using MediatR;
using System.Text;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.JsonFile.Queries.GetAllRecordsFromAPIAllegro
{
    public class GetAllRecordsFromAPIAllegroQueryHandler : IRequestHandler<GetAllRecordsFromAPIAllegroQuery, StringBuilder>
    {
        private readonly IJsonFileRepository _repository;
        private readonly IMapper _mapper;

        public GetAllRecordsFromAPIAllegroQueryHandler(IJsonFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StringBuilder> Handle(GetAllRecordsFromAPIAllegroQuery request, CancellationToken cancellationToken)
        {
            var billingsEntries = await _repository.GetAllAPIAllegro(request.Token);
            StringBuilder builder = new StringBuilder();
            builder.Append(billingsEntries);
            return builder;
        }

    }
}
