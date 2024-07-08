
using MediatR;
using WebApplicationForMilitaria.Domain.Entities.JsonFIle;

namespace WebApplicationForMilitaria.Application.JsonFile.Commands.DeleteJsonFile
{
    public class DeleteJsonFileCommand : BillingEntry, IRequest
    {
        public DeleteJsonFileCommand(int id)
        {
            Id = id;
        }
    }
}
