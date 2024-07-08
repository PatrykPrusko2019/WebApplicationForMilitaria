
using AutoMapper;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Application.FirstProviderFileOne;
using WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.EditProductByIdFirstProviderOneFileCommand;
using WebApplicationForMilitaria.Application.FirstProviderFileTwo.Commands.CreateFirstProviderTwoFile;
using WebApplicationForMilitaria.Application.JsonFile.Commands.CreateJsonFile;
using WebApplicationForMilitaria.Application.JsonFile.Commands.EditJsonFile;
using WebApplicationForMilitaria.Application.JsonFile.DtosJsons;
using WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.EditSecondProviderOneFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.EditSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.ThirdProviderFileOne;
using WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.EditThirdProviderOneFile;
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileTwo;
using WebApplicationForMilitaria.Domain.Entities.JsonFIle;
using WebApplicationForMilitaria.Domain.Entities.ThirdProviderFileOne;

namespace WebApplicationForMilitaria.Application.Mappings
{
    public class WebAppMappingProfile : Profile
    {
        public WebAppMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<ProductOneDto, Domain.Entities.FirstProviderFileOne.Product>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            CreateMap<Domain.Entities.FirstProviderFileOne.Product, ProductOneDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            CreateMap<ProductOneDto, EditProductByIdFirstProviderOneFIleCommand>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));


            CreateMap<Application.SecondProviderFileOne.ProductThreeDto, Domain.Entities.SecondProviderFileOne.Product>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            CreateMap<Domain.Entities.SecondProviderFileOne.Product, Application.SecondProviderFileOne.ProductThreeDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            CreateMap<Application.SecondProviderFileOne.ProductThreeDto, EditSecondProviderOneFileCommand>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            CreateMap<Application.SecondProviderFileTwo.ProductFourDto, Domain.Entities.SecondProviderFileTwo.Product>()
            .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            CreateMap<Domain.Entities.SecondProviderFileTwo.Product, Application.SecondProviderFileTwo.ProductFourDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            CreateMap<Domain.Entities.SecondProviderFileTwo.Photo, Application.SecondProviderFileTwo.PhotoFourDto>();
            CreateMap<Domain.Entities.SecondProviderFileTwo.Category, Application.SecondProviderFileTwo.CategoryFourDto>();

            CreateMap<SecondProviderFileTwo.ProductFourDto, EditSecondProviderTwoFileCommand>()
            .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            CreateMap<ThirdProviderFileOne.ProductFiveDto, Domain.Entities.ThirdProviderFileOne.Product>();
            CreateMap<Domain.Entities.ThirdProviderFileOne.Product, ThirdProviderFileOne.ProductFiveDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            CreateMap<ThirdProviderFileOne.PhotoFiveDto, Domain.Entities.ThirdProviderFileOne.Photo>();
            CreateMap<Domain.Entities.ThirdProviderFileOne.Photo, ThirdProviderFileOne.PhotoFiveDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            CreateMap<Domain.Entities.JsonFIle.BillingEntry, JsonFile.DtosJsons.BillingEntryDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            //FirstProviderSecondFile
            CreateMap<Domain.Entities.FirstProviderFileTwo.Product, FirstProviderFileTwo.ProductTwoDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            CreateMap<Domain.Entities.FirstProviderFileTwo.Icon, FirstProviderFileTwo.IconTwoDto>();
            CreateMap<Domain.Entities.FirstProviderFileTwo.Image, FirstProviderFileTwo.ImageTwoDto>();
            CreateMap<Domain.Entities.FirstProviderFileTwo.Size, FirstProviderFileTwo.SizeTwoDto>();
            CreateMap<Domain.Entities.FirstProviderFileTwo.Parameter, FirstProviderFileTwo.ParameterTwoDto>();


            CreateMap<CreateFirstProviderTwoFileCommand, Domain.Entities.FirstProviderFileTwo.Product>();


            CreateMap<CreateJsonFileCommand, BillingEntry>()
            .ForMember(dto => dto.Tax, opt => opt.MapFrom(src => new Tax() {Percentage = src.Tax.Percentage}))
            .ForMember(dto => dto.Balance, opt => opt.MapFrom(src => new Balance() { Amount = src.Balance.Amount, Currency = src.Balance.Currency }))
            .ForMember(dto => dto.Offer, opt => opt.MapFrom(src => new Offer() { Name = src.Offer.Name, OfferIdJson = src.Offer.OfferIdJson }))
            .ForMember(dto => dto.Order, opt => opt.MapFrom(src => new Order() { OrderIdJson = src.Order.OrderIdJson }))
            .ForMember(dto => dto.Type, opt => opt.MapFrom(src => new Domain.Entities.JsonFIle.Type() { Name = src.Type.Name, TypeIdJson = src.Type.TypeIdJson }))
            .ForMember(dto => dto.Value, opt => opt.MapFrom(src => new Domain.Entities.JsonFIle.Value() { Amount = src.Value.Amount, Currency = src.Value.Currency }));

            CreateMap<BillingEntryDto, EditJsonFileCommand>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => (user != null && src.CreatedById == user.Id) || (user != null && user.Email == "admin@gmail.com")));

            CreateMap<ProductFiveDto ,EditThirdProviderOneFileCommand>();


        }
    }
}
