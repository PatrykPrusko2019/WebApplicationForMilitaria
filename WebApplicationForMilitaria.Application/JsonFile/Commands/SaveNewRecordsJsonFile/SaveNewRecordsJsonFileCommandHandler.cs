using MediatR;
using Newtonsoft.Json;
using WebApplicationForMilitaria.Domain.Interfaces;
using WebApplicationForMilitaria.Domain.JsonList;

namespace WebApplicationForMilitaria.Application.JsonFile.Commands.SaveNewRecordsJsonFile
{
    public class SaveNewRecordsJsonFileCommandHandler : IRequestHandler<SaveNewRecordsJsonFileCommand>
    {
        private readonly IJsonFileRepository _repository;

        public SaveNewRecordsJsonFileCommandHandler(IJsonFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(SaveNewRecordsJsonFileCommand request, CancellationToken cancellationToken)
        {
            BillingEntriesWrapper billingEntriesWrapper = default!;

            try
            {
                var jsonFilePath = "Files/Records.json";
                var jsonStrings = await File.ReadAllTextAsync(jsonFilePath);

                billingEntriesWrapper = JsonConvert.DeserializeObject<BillingEntriesWrapper>(jsonStrings);
                await _repository.SaveToDatabase(billingEntriesWrapper);
            }
            catch (Exception ex)
            {
               await Console.Out.WriteLineAsync($"An error occurred: {ex.Message}");
            }

            return Unit.Value;
        }


    }
}
