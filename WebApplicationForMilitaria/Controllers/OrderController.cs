using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Application.JsonFile.Commands.CreateJsonFile;
using WebApplicationForMilitaria.Application.JsonFile.Commands.DeleteJsonFile;
using WebApplicationForMilitaria.Application.JsonFile.Commands.EditJsonFile;
using WebApplicationForMilitaria.Application.JsonFile.Queries.GetAllRecordsJsonFile;
using WebApplicationForMilitaria.Application.JsonFile.Queries.GetRecordByIdJsonFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.DeleteSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Queries.GetRecordByIdSecondProviderTwoFile;

namespace WebApplicationForMilitaria.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _toastService;

        public OrderController(IMediator mediator, IMapper mapper, INotyfService notyfService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _toastService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _mediator.Send(new GetAllRecordsJsonFileQuery());

            return View(records);
        }

        [Authorize]
        public IActionResult Create()
        {
            //if (User.Identity == null || !User.Identity.IsAuthenticated)
            //{
            //    return RedirectToPage("/Account/Login", new { area = "Identity" });
            //}

            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateJsonFileCommand product)
        {

            if (!ModelState.IsValid)
            {
                _toastService.Error("No Product Added");
                return View(product);
            }

            await _mediator.Send(product);
            _toastService.Success("Product Added");
            return RedirectToAction(nameof(Index));
        }

        [Route("Order/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var recordDto = await _mediator.Send(new GetRecordByIdJsonFileQuery(id));

            if (!recordDto.IsEditable)
            {
                _toastService.Error("no product updated -> you don't have access, only his creator");
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<EditJsonFileCommand>(recordDto);

            return View(model);
        }

        [HttpPost]
        [Route("Order/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditJsonFileCommand product)
        {
            

            await _mediator.Send(product);
            _toastService.Success("Updated given product");
            return RedirectToAction(nameof(Index));
        }

        [Route("Order/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            CurrentUser.IdRecord = id;
            var recordDto = await _mediator.Send(new GetRecordByIdJsonFileQuery(id));
            return View(recordDto);
        }

        [Route("Order/{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var productDto = await _mediator.Send(new GetRecordByIdJsonFileQuery(id));

            await _mediator.Send(new DeleteJsonFileCommand(id));
            _toastService.Success("Deleted given Project");
            return RedirectToAction(nameof(Index));
        }


    }
}
