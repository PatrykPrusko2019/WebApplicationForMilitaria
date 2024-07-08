
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForMilitaria.Application.ApplicationUser;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.CreatePhotoCategoryModal;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.CreateSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.DeleteCategorySecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.DeletePhotoSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.DeleteSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Commands.EditSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Queries.GetAllRecordsSecondProviderTwoFile;
using WebApplicationForMilitaria.Application.SecondProviderFileTwo.Queries.GetRecordByIdSecondProviderTwoFile;

namespace WebApplicationForMilitaria.MVC.Controllers
{
    
    public class SecondProviderFileTwoController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _toastService;

        public SecondProviderFileTwoController(IMediator mediator, IMapper mapper, INotyfService toastService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _toastService = toastService;  
        }

        public async Task<IActionResult> Index()
        {
            var records = await _mediator.Send(new GetAllRecordsSecondProviderTwoFileQuery());
            
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
        public async Task<IActionResult> Create(CreateSecondProviderTwoFileCommand product)
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


        [HttpPost]
        public async Task<IActionResult> CreatePhotoCategory(CreatePhotoCategoryCommand product)
        {
            product.ProductId = CurrentUser.IdRecord;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(product);
            return Ok();
        }

        [Route("SecondProviderFileTwo/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var productDto = await _mediator.Send(new GetRecordByIdSecondProviderTwoFileQuery(id));

            if (!productDto.IsEditable)
            {
                _toastService.Error("no product updated -> you don't have access, only his creator");
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<EditSecondProviderTwoFileCommand>(productDto);

            return View(model);
        }

        [HttpPost]
        [Route("SecondProviderFileTwo/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditSecondProviderTwoFileCommand product)
        {
            await _mediator.Send(product);
            _toastService.Success("Updated given product");
            return RedirectToAction(nameof(Index));
        }

     

        [Route("SecondProviderFileTwo/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            CurrentUser.IdRecord = id;
            var productDto = await _mediator.Send(new GetRecordByIdSecondProviderTwoFileQuery(id));
            return View(productDto);
        }

        [Route("SecondProviderFileTwo/{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var productDto = await _mediator.Send(new GetRecordByIdSecondProviderTwoFileQuery(id));

            await _mediator.Send(new DeleteSecondProviderTwoFileCommand(id));
            _toastService.Success("Deleted given Project");
            return RedirectToAction(nameof(Index));
        }

        [Route("SecondProviderFileTwo/{id}/DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _mediator.Send(new DeleteCategorySecondProviderTwoFileCommand(id));

            _toastService.Success("Deleted given Category");
            return RedirectToRoute(new { controller = "SecondProviderFileTwo", action = "Details", id = CurrentUser.IdRecord });
        }

        [Route("SecondProviderFileTwo/{id}/DeletePhoto")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            await _mediator.Send(new DeletePhotoSecondProviderTwoFileCommand(id));
            _toastService.Success("Deleted given Photo");
            return RedirectToRoute(new { controller = "SecondProviderFileTwo", action = "Details", id = CurrentUser.IdRecord });
        }
        

    }
}
