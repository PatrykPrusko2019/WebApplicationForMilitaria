
using AspNetCoreHero.ToastNotification;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.CreateFirstProviderOneFileCommand;
using WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.EditProductByIdFirstProviderOneFileCommand;
using WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.SaveNewRecordsInTheDatabase;
using WebApplicationForMilitaria.Application.FirstProviderFileTwo.Commands.CreateFirstProviderTwoFile;
using WebApplicationForMilitaria.Application.FirstProviderFileTwo.Commands.SaveNewRecordsFirstProviderTwoFile;
using WebApplicationForMilitaria.Application.JsonFile.Commands.CreateJsonFile;
using WebApplicationForMilitaria.Application.JsonFile.Commands.EditJsonFile;
using WebApplicationForMilitaria.Application.JsonFile.Commands.SaveNewRecordsJsonFile;
using WebApplicationForMilitaria.Application.Mappings;
using WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.CreateSecondProviderOneFile;
using WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.EditSecondProviderOneFile;
using WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.SaveNewRecordsSecondProviderOneFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.CreatePhotoCategoryModal;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.CreateSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.EditSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.SaveNewRecordsSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.CreateThirdProviderOneFile;
using WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.EditThirdProviderOneFile;
using WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.SaveNewRecordsThirdProviderOneFile;
using WebApplicationForMilitaria.Application.User.Commands.CreateRole;

namespace WebApplicationForMilitaria.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();

            services.AddMediatR(typeof(CreateRoleUserCommand));
            
            services.AddMediatR(typeof(SaveNewRecordsFirstProviderOneFileCommand));
            services.AddMediatR(typeof(SaveNewRecordsFirstProviderTwoFileCommand));
            services.AddMediatR(typeof(SaveNewRecordsSecondProviderOneFileCommand));
            services.AddMediatR(typeof(SaveNewRecordsSecondProviderTwoFileCommand));
            services.AddMediatR(typeof(SaveNewRecordsThirdProviderOneFileCommand));
            services.AddMediatR(typeof(SaveNewRecordsJsonFileCommand));

            services.AddMediatR(typeof(CreateFirstProviderOneFileCommand));

            services.AddMediatR(typeof(CreatePhotoCategoryCommand));

            services.AddMediatR(typeof(CreateJsonFileCommand));

            services.AddMediatR(typeof(CreateFirstProviderTwoFileCommand));

            services.AddMediatR(typeof(EditProductByIdFirstProviderOneFIleCommand));

            services.AddMediatR(typeof(EditSecondProviderOneFileCommand));

            services.AddMediatR(typeof(EditSecondProviderTwoFileCommand));

            services.AddMediatR(typeof(EditJsonFileCommand));

            services.AddMediatR(typeof(EditThirdProviderOneFileCommand));

            services.AddMediatR(typeof(CreateSecondProviderOneFileCommand));

            services.AddMediatR(typeof(CreateSecondProviderTwoFileCommand));

            services.AddMediatR(typeof(CreateThirdProviderOneFileCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new WebAppMappingProfile(userContext));
            }).CreateMapper()
            );

            services.AddAutoMapper(typeof(WebAppMappingProfile));

            services.AddValidatorsFromAssemblyContaining<EditProductByIdFirstProviderOneFIleCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<EditSecondProviderOneFileCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateSecondProviderOneFileCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateFirstProviderOneFileCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateSecondProviderTwoFileCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreatePhotoCategoryCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<EditSecondProviderTwoFileCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateFirstProviderTwoFileCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            
            services.AddValidatorsFromAssemblyContaining<EditThirdProviderOneFileCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<EditJsonFileCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateJsonFileCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();







            services.AddNotyf(config => { config.DurationInSeconds = 3; config.IsDismissable = true; config.Position = NotyfPosition.TopCenter; });
        }
    }
}
