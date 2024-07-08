
using MediatR;
using System.Xml.Serialization;
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.SaveNewRecordsInTheDatabase
{
    public class SaveNewRecordsFirstProviderOneFileCommandHandler : IRequestHandler<SaveNewRecordsFirstProviderOneFileCommand>
    {
        private readonly IFirstProviderOneFileRepository _repository;

        public SaveNewRecordsFirstProviderOneFileCommandHandler(IFirstProviderOneFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(SaveNewRecordsFirstProviderOneFileCommand request, CancellationToken cancellationToken)
        {
            string xmlFilePath = "Files/dostawca1plik1.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Offer));

            Offer offer;
            using (StreamReader reader = new StreamReader(xmlFilePath))
            {
                offer = (Offer)serializer.Deserialize(reader);
            }

            await _repository.SaveToDatabase(offer);

            return Unit.Value;
        }
    }
}
