
using MediatR;
using WebApplicationForMilitaria.Application.JsonFile.DtosJsons;

namespace WebApplicationForMilitaria.Application.JsonFile.Commands.CreateJsonFile
{
    public class CreateJsonFileCommand : BillingEntryDto, IRequest
    {
    }
}
