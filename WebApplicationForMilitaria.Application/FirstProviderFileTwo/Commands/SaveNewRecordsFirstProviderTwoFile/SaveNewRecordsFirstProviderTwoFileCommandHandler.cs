using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;
using System.Xml.Linq;
using AutoMapper;

namespace WebApplicationForMilitaria.Application.FirstProviderFileTwo.Commands.SaveNewRecordsFirstProviderTwoFile
{
    public class SaveNewRecordsFirstProviderTwoFileCommandHandler : IRequestHandler<SaveNewRecordsFirstProviderTwoFileCommand>
    {
        private readonly IFIrstProviderTwoFileRepository _repository;
        private readonly IMapper _mapper;

        public SaveNewRecordsFirstProviderTwoFileCommandHandler(IFIrstProviderTwoFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(SaveNewRecordsFirstProviderTwoFileCommand request, CancellationToken cancellationToken)
        {
            string xmlFilePath = @"Files/dostawca1plik2.xml";
            var xmlDocument = XDocument.Load(xmlFilePath);
            XNamespace ns = "http://www.iai-shop.com/developers/iof/extensions.phtml";

            var products = new List<Domain.FirstProviderFileTwoXML.Product>();

            foreach (var productElement in xmlDocument.Descendants("product"))
            {
                var product = new Domain.FirstProviderFileTwoXML.Product
                {
                    Id = int.Parse(productElement.Attribute("id").Value),
                    ProducerId = productElement.Element("producer").Attribute("id").Value,
                    CategoryId = productElement.Element("category").Attribute("id").Value,
                    UnitId = productElement.Element("unit").Attribute("id").Value,
                    WarrantyId = productElement.Element("warranty").Attribute("id").Value,
                    CardUrl = productElement.Element("card").Attribute("url").Value,
                    Name = productElement.Element("description").Elements("name").First().Value,
                    Description = productElement.Element("description").Elements("long_desc").First().Value,
                    PriceNet = decimal.Parse(productElement.Element("price").Attribute("net").Value),
                    PriceGross = decimal.Parse(productElement.Element("price").Attribute("gross").Value),
                    SrvNet = decimal.Parse(productElement.Element("srp").Attribute("net").Value),
                    SrvGross = decimal.Parse(productElement.Element("srp").Attribute("gross").Value),
                    Images = productElement.Descendants("image").Select(i => new Domain.FirstProviderFileTwoXML.Image
                    {
                        Url = i.Attribute("url").Value,
                        Height = int.Parse(i.Attribute(ns + "height").Value),
                        Width = int.Parse(i.Attribute(ns + "width").Value)
                    }).ToList(),
                    Icons = productElement.Descendants("icon").Select(ic => new Domain.FirstProviderFileTwoXML.Icon
                    {
                        Url = ic.Attribute("url").Value,
                        Height = int.Parse(ic.Attribute(ns + "height").Value),
                        Width = int.Parse(ic.Attribute(ns + "width").Value)
                    }).ToList(),
                    Sizes = productElement.Descendants("size").Select(s => new Domain.FirstProviderFileTwoXML.Size
                    {
                        CodeProducer = s.Attribute("code_producer").Value,
                        Code = s.Attribute("code").Value,
                        PriceNet = decimal.Parse(s.Element("price").Attribute("net").Value),
                        PriceGross = decimal.Parse(s.Element("price").Attribute("gross").Value),
                        SrvNet = decimal.Parse(s.Element("srp").Attribute("net").Value),
                        SrvGross = decimal.Parse(s.Element("srp").Attribute("gross").Value),
                        StockId = int.Parse(s.Element("stock").Attribute("id").Value),
                        Quantity = int.Parse(s.Element("stock").Attribute("quantity").Value)
                    }).ToList(),
                    Parameters = productElement.Descendants("parameter").Select(p => new Domain.FirstProviderFileTwoXML.Parameter
                    {
                        Id = int.Parse(p.Attribute("id").Value),
                        Name = p.Attribute("name").Value,
                        Value = p.Element("value").Attribute("name").Value
                    }).ToList()
                };

                products.Add(product);
            }


            await _repository.SaveToDatabase(products);


            return Unit.Value;
        }

    }

}
