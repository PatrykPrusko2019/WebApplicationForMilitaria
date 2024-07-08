
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationForMilitaria.Domain.Interfaces;
using WebApplicationForMilitaria.Infrastructure.Persistance;
using WebApplicationForMilitaria.Infrastructure.Repositories;
using WebApplicationForMilitaria.Infrastructure.Seeders;

namespace WebApplicationForMilitaria.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebAppDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("WebAppDb"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<WebAppDbContext>();
                

            services.AddScoped<WebAppForMilitariaSeeder>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJsonFileRepository, JsonFileRepository>();
            services.AddScoped<IFirstProviderOneFileRepository, FirstProviderOneFileRepository>();
            services.AddScoped<IFIrstProviderTwoFileRepository, FIrstProviderTwoFileRepository>();
            services.AddScoped<ISecondProviderOneFileRepository, SecondProviderOneFileRepository>();
            services.AddScoped<ISecondProviderTwoFileRepository, SecondProviderTwoFileRepository>();
            services.AddScoped<IThirdProviderOneFileRepository, ThirdProviderOneFileRepository>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }
    }
}
