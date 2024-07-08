
using AutoMapper;
using MediatR;
using NuGet.Protocol.Core.Types;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileOne.Queries.GetRecordByIdSecondProviderOneFile
{
    public class GetRecordByIdSecondProviderOneFileQueryHandler : IRequestHandler<GetRecordByIdSecondProviderOneFileQuery, ProductThreeDto>
    {
        private readonly ISecondProviderOneFileRepository _repository;
        private readonly IMapper _mapper;

        public GetRecordByIdSecondProviderOneFileQueryHandler(ISecondProviderOneFileRepository secondProviderOneFileRepository, IMapper mapper)
        {
            _repository = secondProviderOneFileRepository;
            _mapper = mapper;
        }

        public async Task<ProductThreeDto> Handle(GetRecordByIdSecondProviderOneFileQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);

            var productDto = _mapper.Map<ProductThreeDto>(product);

            return productDto;
        }
    }
}
