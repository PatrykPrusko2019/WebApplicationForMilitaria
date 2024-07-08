using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Application.FirstProviderFileTwo.Commands.CreateFirstProviderTwoFile;
using WebApplicationForMilitaria.Application.FirstProviderFileTwo.Commands.DeleteFirstProviderTwoFile;
using WebApplicationForMilitaria.Application.FirstProviderFileTwo.Commands.SaveNewRecordsFirstProviderTwoFile;
using WebApplicationForMilitaria.Application.FirstProviderFileTwo.Queries.GetAllRecordsFirstProviderTwoFile;
using WebApplicationForMilitaria.Application.FirstProviderFileTwo.Queries.GetRecordByIdFirstProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.CreateSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.DeleteSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Queries.GetRecordByIdSecondProviderTwoFile;

namespace WebApplicationForMilitaria.MVC.Controllers
{
    public class FirstProviderFileTwoController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _toastService;
        private static bool isUse {  get; set; } = true;

        public FirstProviderFileTwoController(IMediator mediator, IMapper mapper, INotyfService toastService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _toastService = toastService;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _mediator.Send(new GetAllRecordsFirstProviderTwoFileQuery());

            if (records == null || (records.Count() == 0 && isUse == true))
            {
                await _mediator.Send(new SaveNewRecordsFirstProviderTwoFileCommand());
                records = await _mediator.Send(new GetAllRecordsFirstProviderTwoFileQuery());
                isUse = false;
            }
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
        public async Task<IActionResult> Create(CreateFirstProviderTwoFileCommand product)
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

        [Route("FirstProviderFileTwo/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            CurrentUser.IdRecord = id;
            var productDto = await _mediator.Send(new GetRecordByIdFirstProviderTwoFileQuery(id));
            return View(productDto);
        }

        [Route("FirstProviderFileTwo/{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var productDto = await _mediator.Send(new GetRecordByIdFirstProviderTwoFileQuery(id));

            await _mediator.Send(new DeleteFirstProviderTwoFileCommand(id));
            _toastService.Success("Deleted given Project");
            return RedirectToAction(nameof(Index));
        }
    }
}
