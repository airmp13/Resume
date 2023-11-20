using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Implements;
using Resume.Application.Services.Interfaces;

namespace Resume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutMeController : Controller
    {
        private readonly IAboutMeService _aboutMeService;

        public AboutMeController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
            
        }
        public async Task<IActionResult> Index()
        {
            
            return View(await _aboutMeService.GetAboutMesDTOAsync());
        }
    }
}
