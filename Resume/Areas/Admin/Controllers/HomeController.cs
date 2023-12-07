using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;

namespace Resume.Areas.Admin.Controllers
{
    
    [Area("Admin"),Authorize]
    
    public class HomeController : Controller
    {
		private readonly IAdminHomePageService _adminHomePageService;

		public HomeController(IAdminHomePageService adminHomePageService)
        {
			_adminHomePageService = adminHomePageService;
		}

        public async Task<IActionResult> Index()
        {
            return View(await _adminHomePageService.GetAll());
        }
    }
}
