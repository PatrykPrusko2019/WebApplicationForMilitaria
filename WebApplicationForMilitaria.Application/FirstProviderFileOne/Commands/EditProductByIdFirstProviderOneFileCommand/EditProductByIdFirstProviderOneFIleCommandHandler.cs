using AutoMapper;
using MediatR;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.EditProductByIdFirstProviderOneFileCommand
{
    public class EditProductByIdFirstProviderOneFIleCommandHandler : IRequestHandler<EditProductByIdFirstProviderOneFIleCommand>
    {
        private readonly IFirstProviderOneFileRepository _repository;
        
        public EditProductByIdFirstProviderOneFIleCommandHandler(IFirstProviderOneFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditProductByIdFirstProviderOneFIleCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);

            product.Price = request.Price;  
            product.Srp = request.Srp;
            product.Sizes = request.Sizes;
            
            await _repository.Commit();

            return Unit.Value;
        }
    }
}
