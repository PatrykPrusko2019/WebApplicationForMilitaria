using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.CreateSecondProviderOneFile;
using WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.DeleteSecondProviderOneFile;
using WebApplicationForMilitaria.Application.SecondProviderFileOne.Commands.EditSecondProviderOneFile;
using WebApplicationForMilitaria.Application.SecondProviderFileOne.Queries.GetAllRecordsSecondProviderOneFile;
using WebApplicationForMilitaria.Application.SecondProviderFileOne.Queries.GetRecordByIdSecondProviderOneFile;

namespace WebApplicationForMilitaria.MVC.Controllers
{
    public class SecondProviderFileOneController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _toastService;

        public SecondProviderFileOneController(IMediator mediator, IMapper mapper, INotyfService notyfService)
        { 
            _mediator = mediator;
            _mapper = mapper;
            _toastService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _mediator.Send(new GetAllRecordsSecondProviderOneFileQuery());
            
            return View(records);
        }


        [Authorize]
        public IActionResult Create()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateSecondProviderOneFileCommand product)
        {
            if (!ModelState.IsValid)
            {
                _toastService.Error("No Product Added");
                return View(product);
            }


            await _mediator.Send(product);
            _toastService.Success("Added new Product");
            return RedirectToAction(nameof(Index));
        }

        [Route("SecondProviderFileOne/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var productDto = await _mediator.Send(new GetRecordByIdSecondProviderOneFileQuery(id));


            // _toastService.Error("no product updated");

            var model = _mapper.Map<EditSecondProviderOneFileCommand>(productDto);

            return View(model);
        }

        [HttpPost]
        [Route("SecondProviderFileOne/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditSecondProviderOneFileCommand product)
        {
            
            

            await _mediator.Send(product);
            _toastService.Success("Updated given Product");
            return RedirectToAction(nameof(Index));
        }

        [Route("SecondProviderFileOne/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var productDto = await _mediator.Send(new GetRecordByIdSecondProviderOneFileQuery(id));
            return View(productDto);
        }

        [Route("SecondProviderFileOne/{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteSecondProviderOneFileCommand(id));
            _toastService.Success("Deleted given Product");
            return RedirectToAction(nameof(Index));
        }
    }
}
