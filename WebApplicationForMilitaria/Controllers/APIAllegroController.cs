using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Helpers;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApplicationForMilitaria.Application.FirstProviderFileOne.Queries.GetAllRecords;
using WebApplicationForMilitaria.Application.JsonFile.Queries.GetAllRecordsFromAPIAllegro;

namespace WebApplicationForMilitaria.MVC.Controllers
{
    public class APIAllegroController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _toastService;

        StringBuilder builder = new StringBuilder();
        public static string FullToken { get; set; }

        public APIAllegroController(IMediator mediator, IMapper mapper, INotyfService toastService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _toastService = toastService;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _mediator.Send(new GetAllRecordsFromAPIAllegroQuery(builder));

            if (records.ToString() != "") 
            {
                ViewBag.FileContent = records.ToJson().ToString();
            }
            else
            {
                ViewBag.FileContent = "File does not exist.";
                _toastService.Error("Files from API Allegro not downloaded");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitDataFirst(string token)
        {
            FullToken = token;
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> SubmitDataSecond(string token)
        {
           builder.Append(FullToken);
           builder.Append(token);
            
            var records = await _mediator.Send(new GetAllRecordsFromAPIAllegroQuery(builder));

            if (records.ToString() != "Something wrong" && records.ToString().Count() > 1)
            {
                _toastService.Success("Files from API Allegro downloaded");
            }

            ViewBag.Message = records.ToJson().ToString();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetFilesFromFileTokenTxt()
        {
            var records = await _mediator.Send(new GetAllRecordsFromAPIAllegroQuery(builder.Append("Files/token.txt")));

            if (records.ToString() != "Something wrong" && records.ToString().Count() > 1)
            {
                _toastService.Success("Files from API Allegro downloaded (from Files/token.txt)");
            }
            else
            {
                _toastService.Error("Wrong token in file token.txt");
            }

            ViewBag.Message = records.ToJson().ToString();
            return RedirectToAction("Index");
        }
    }
}
