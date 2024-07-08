
using MediatR;
using System.Xml.Serialization;
using WebApplicationForMilitaria.Domain.Interfaces;
using WebApplicationForMilitaria.Domain.SecondProviderFileTwoXML;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.SaveNewRecordsSecondProviderTwoFile
{
    public class SaveNewRecordsSecondProviderTwoFileCommandHandler : IRequestHandler<SaveNewRecordsSecondProviderTwoFileCommand>
    {
        private readonly ISecondProviderTwoFileRepository _repository;

        public SaveNewRecordsSecondProviderTwoFileCommandHandler(ISecondProviderTwoFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(SaveNewRecordsSecondProviderTwoFileCommand request, CancellationToken cancellationToken)
        {
            string xmlFilePath = @"Files/dostawca2plik2.xml";
            xmlFilePath = File.ReadAllText(xmlFilePath);

            ProductsXml productsXml = Deserialize(xmlFilePath);

            await _repository.SaveToDatabase(productsXml.ProductList);

            return Unit.Value;
        }

        public ProductsXml Deserialize(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProductsXml));
            using (StringReader reader = new StringReader(xml))
            {
                return (ProductsXml)serializer.Deserialize(reader);
            }
        }
    }
}
