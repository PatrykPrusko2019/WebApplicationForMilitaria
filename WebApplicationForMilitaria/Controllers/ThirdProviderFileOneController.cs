using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.EditSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Queries.GetRecordByIdSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.CreateThirdProviderOneFile;
using WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.DeleteThirdProviderOneFile;
using WebApplicationForMilitaria.Application.ThirdProviderFileOne.Commands.EditThirdProviderOneFile;
using WebApplicationForMilitaria.Application.ThirdProviderFileOne.Queries.GetAllRecords;
using WebApplicationForMilitaria.Application.ThirdProviderFileOne.Queries.GetRecordByIdThirdProviderOneFile;

namespace WebApplicationForMilitaria.MVC.Controllers
{
    public class ThirdProviderFileOneController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _toastService;
        public ThirdProviderFileOneController(IMediator mediator, IMapper mapper, INotyfService toastService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _toastService = toastService;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _mediator.Send(new GetAllRecordsThirdProviderOneFileQuery());

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
        public async Task<IActionResult> Create(CreateThirdProviderOneFileCommand product)
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

        [Route("ThirdProviderFileOne/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            CurrentUser.IdRecord = id;
            var productDto = await _mediator.Send(new GetRecordByIdThirdProviderOneFileQuery(id));
            return View(productDto);
        }

        [Route("ThirdProviderFileOne/{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var productDto = await _mediator.Send(new GetRecordByIdThirdProviderOneFileQuery(id));

            await _mediator.Send(new DeleteThirdProviderOneFileCommand(id));
            _toastService.Success("Deleted given Project");
            return RedirectToAction(nameof(Index));
        }

        [Route("ThirdProviderFileOne/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var productDto = await _mediator.Send(new GetRecordByIdThirdProviderOneFileQuery(id));

            if (!productDto.IsEditable)
            {
                _toastService.Error("no product updated -> you don't have access, only his creator");
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<EditThirdProviderOneFileCommand>(productDto);

            return View(model);
        }

        [HttpPost]
        [Route("ThirdProviderFileOne/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditThirdProviderOneFileCommand product)
        {
            await _mediator.Send(product);
            _toastService.Success("Updated given product");
            return RedirectToAction(nameof(Index));
        }

    }
}
