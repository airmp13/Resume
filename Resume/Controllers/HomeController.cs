using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Resume.Application.DTOs.Site;
using Resume.Application.Services.Interfaces;
using Resume.Domain;
using Resume.Domain.Entities;

namespace Resume.Controllers
{
    public class HomeController : Controller
    {

        ISinglePageService _SinglePageService;

        public HomeController(ISinglePageService SinglePageService)
        {
            _SinglePageService = SinglePageService;
        }

        public IActionResult View3(Exception exception)
        {
            return View(exception);
        }

        public async Task<IActionResult> Index()
        {
            
                SinglePageDTO singlePageDTO = await _SinglePageService.GetSinglePageDTOAsync();
                return View(singlePageDTO);
            
            
                
           
            
        }

        [HttpPost]
		public async Task<IActionResult> Index(ContactMeDTO contactMeDTO)
		{
            _SinglePageService.submitContactme(contactMeDTO);
			return RedirectToAction("Index");
		}



	}
}