
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.SaveNewRecordsInTheDatabase;
using WebApplicationForMilitaria.Application.FirstProviderFileTwo.Commands.SaveNewRecordsFirstProviderTwoFile;
using WebApplicationForMilitaria.Application.JsonFile.Commands.SaveNewRecordsJsonFile;
using WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.SaveNewRecordsSecondProviderOneFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.SaveNewRecordsSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.SaveNewRecordsThirdProviderOneFile;
using WebApplicationForMilitaria.Application.User.Commands.CreateRole;
using WebApplicationForMilitaria.Infrastructure.Persistance;

namespace WebApplicationForMilitaria.Infrastructure.Seeders
{
    public class WebAppForMilitariaSeeder
    {
        private readonly WebAppDbContext _dbContext;
        private readonly IMediator _mediator;

        public WebAppForMilitariaSeeder(WebAppDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task Seed()
        {
            if (!await _dbContext.Database.CanConnectAsync())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                //if (!_dbContext.Roles.Any())
                //{
                //    await _mediator.Send(new CreateRoleUserCommand());
                //}

                if (!_dbContext.BillingEntries.Any())
                {
                    await _mediator.Send(new SaveNewRecordsJsonFileCommand());
                }

                if (!_dbContext.Products.Any())
                {
                    await _mediator.Send(new SaveNewRecordsFirstProviderOneFileCommand());
                }

                if (!_dbContext.Products2.Any())
                {
                    await _mediator.Send(new SaveNewRecordsSecondProviderOneFileCommand());
                }

                if (!_dbContext.Products3.Any())
                {
                    await _mediator.Send(new SaveNewRecordsSecondProviderTwoFileCommand());
                }

                if (!_dbContext.Products4.Any())
                {
                    await _mediator.Send(new SaveNewRecordsThirdProviderOneFileCommand());
                }
                
            }
        }
    }
}
