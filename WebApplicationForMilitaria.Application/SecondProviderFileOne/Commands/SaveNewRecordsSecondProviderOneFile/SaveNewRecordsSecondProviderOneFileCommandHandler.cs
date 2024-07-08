
using MediatR;
using System.Xml.Serialization;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileOne;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.SaveNewRecordsSecondProviderOneFile
{
    public class SaveNewRecordsSecondProviderOneFileCommandHandler : IRequestHandler<SaveNewRecordsSecondProviderOneFileCommand>
    {
        private readonly ISecondProviderOneFileRepository _repository;

        public SaveNewRecordsSecondProviderOneFileCommandHandler(ISecondProviderOneFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(SaveNewRecordsSecondProviderOneFileCommand request, CancellationToken cancellationToken)
        {
            string xmlFilePath = @"Files/dostawca2plik1.xml";
            xmlFilePath = File.ReadAllText(xmlFilePath);

            Products products = Deserialize(xmlFilePath);

             await _repository.SaveToDatabase(products);

            return Unit.Value;
        }

        public Products Deserialize(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Products));
            using (StringReader reader = new StringReader(xml))
            {
                return (Products)serializer.Deserialize(reader);
            }
        }

    }

}
