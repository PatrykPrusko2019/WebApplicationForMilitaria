
using MediatR;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileTwo;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.CreatePhotoCategoryModal
{
    public class CreatePhotoCategoryCommandHandler : IRequestHandler<CreatePhotoCategoryCommand>
    {
        private readonly ISecondProviderTwoFileRepository _repository;
        private readonly IUserContext _userContext;

        public CreatePhotoCategoryCommandHandler(ISecondProviderTwoFileRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreatePhotoCategoryCommand request, CancellationToken cancellationToken)
        {
            request.ProductId = CurrentUser.IdRecord;

            var product = await _repository.GetProductById(request.ProductId);

            if (product.Photos == null || product.Photos.Count == 0) product.Photos = new List<Photo>();
            if (product.Categories == null || product.Categories.Count == 0) product.Categories = new List<Category>();


            if (request.Url == "empty" && request.CategoryName == "empty") return Unit.Value;
            else if (request.Url == "empty")
            {
                product.Categories.Add(new Category() { Name = request.CategoryName, CategoryIdXML = "" });
            }
            else if (request.CategoryName == "empty")
            {
                product.Photos.Add(new Photo() { Url = request.Url, IsMain = request.IsMain, ProductId = product.ProductId });
            }
            else
            {
                product.Categories.Add(new Category() { Name = request.CategoryName, CategoryIdXML = "" });
                product.Photos.Add(new Photo() { Url = request.Url, IsMain = request.IsMain, ProductId = product.ProductId });
            }

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
