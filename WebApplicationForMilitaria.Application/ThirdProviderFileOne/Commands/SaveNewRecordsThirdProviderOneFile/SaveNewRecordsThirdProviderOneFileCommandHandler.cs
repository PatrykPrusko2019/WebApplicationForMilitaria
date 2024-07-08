
using MediatR;
using System.Xml.Serialization;
using WebApplicationForMilitaria.Domain.Interfaces;
using WebApplicationForMilitaria.Domain.ThirdProviderFileOneXML;

namespace WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.SaveNewRecordsThirdProviderOneFile
{
    public class SaveNewRecordsThirdProviderOneFileCommandHandler : IRequestHandler<SaveNewRecordsThirdProviderOneFileCommand>
    {
        private readonly IThirdProviderOneFileRepository _repository;

        public SaveNewRecordsThirdProviderOneFileCommandHandler(IThirdProviderOneFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(SaveNewRecordsThirdProviderOneFileCommand request, CancellationToken cancellationToken)
        {
            string xmlFilePath = @"Files/dostawca3plik1.xml";
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
