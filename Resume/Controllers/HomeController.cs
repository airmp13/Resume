using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Resume.Application;
using Resume.Domain;

namespace Resume.Controllers
{
    public class HomeController : Controller
    {

        IAllDTOService _allDTOService;

        public HomeController(IAllDTOService allDTOService)
        {
            _allDTOService = allDTOService;
        }

        public IActionResult View3(Exception exception)
        {
            return View(exception);
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                AllDTO allDTO = await _allDTOService.GetAllDTOAsync();
                return View(allDTO);
            }
            catch (Exception ex)
            {
                //throw new Exception("error");
                return RedirectToAction("View3", routeValues: new {ex2= ex });
            }
                
           
            
        }

        [HttpPost]
		public async Task<IActionResult> Index(ContactMe contactMe)
		{
            _allDTOService.submitContactme(contactMe);
			return RedirectToAction("Index");
		}



	}
}