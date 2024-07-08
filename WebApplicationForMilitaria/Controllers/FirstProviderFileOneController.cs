using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.CreateFirstProviderOneFileCommand;
using WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.DeleteFirstProviderOneFile;
using WebApplicationForMilitaria.Application.FirstProviderFileOne.Commands.EditProductByIdFirstProviderOneFileCommand;
using WebApplicationForMilitaria.Application.FirstProviderFileOne.Queries.GetAllRecords;
using WebApplicationForMilitaria.Application.FirstProviderFileOne.Queries.GetProductByIdFirstProviderOneFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.DeleteSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Queries.GetRecordByIdSecondProviderTwoFile;

namespace WebApplicationForMilitaria.MVC.Controllers
{
    public class FirstProviderFileOneController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _toastService;

        public FirstProviderFileOneController(IMediator mediator, IMapper mapper, INotyfService toastService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _toastService = toastService;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _mediator.Send(new GetAllRecordsFirstProviderOneFileQuery());
           
            return View(records);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateFirstProviderOneFileCommand product)
        {
            product.CreatedById = "";
            product.Sizes = new Domain.Entities.FirstProviderFileOne.Sizes();
            product.Sizes.SizeList = new List<Domain.Entities.FirstProviderFileOne.Size>
            {
                product.Size
            };
            product.Sizes.SizeList.FirstOrDefault()!.Stock = product.Stock;


            await _mediator.Send(product);
            _toastService.Success("Product Added");
            return RedirectToAction(nameof(Index));
        }

        [Route("FirstProviderFileOne/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var records = await _mediator.Send(new GetAllRecordsFirstProviderOneFileQuery());

            var productDto = records.FirstOrDefault(p => p.ProductId == id);
            if (productDto.Sizes != null && productDto.Sizes.SizeList != null && productDto.Sizes.SizeList.Count() > 0) productDto.Size = productDto.Sizes.SizeList[0];
            if (productDto.Sizes.SizeList[0].Stock != null) productDto.Stock = productDto.Sizes.SizeList[0].Stock;


            return View(productDto);
        }

        [Route("FirstProviderFileOne/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var productDto = await _mediator.Send(new GetProductByIdFirstProviderOneFileQuery(id));

            if (!productDto.IsEditable)
            {
                _toastService.Error("no product updated -> you don't have access, only his creator");
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<EditProductByIdFirstProviderOneFIleCommand>(productDto);

            return View(model);
        }

        [HttpPost]
        [Route("FirstProviderFileOne/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditProductByIdFirstProviderOneFIleCommand product)
        {
            if (product.Size != null)
            {
                if (product.Stock != null) product.Size.Stock = product.Stock;

                if (product.Sizes != null && product.Sizes.SizeList != null) product.Sizes.SizeList[0] = product.Size;
                else
                {
                    if (product.Sizes == null) product.Sizes = new Domain.Entities.FirstProviderFileOne.Sizes();
                    product.Sizes.SizeList = new List<Domain.Entities.FirstProviderFileOne.Size>() { product.Size };
                }
            }
            product.Size!.Code = "";
            product.Size!.CodeProducer = "";
            await _mediator.Send(product);
           _toastService.Success("Updated given Employee");
            return RedirectToAction(nameof(Index));
        }

        [Route("FirstProviderFileOne/{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var productDto = await _mediator.Send(new GetProductByIdFirstProviderOneFileQuery(id));

            await _mediator.Send(new DeleteFirstProviderOneFileCommand(id));
            _toastService.Success("Deleted given Project");
            return RedirectToAction(nameof(Index));
        }

    }
}
