using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Site;
using Resume.Application.Services.Implements;
using Resume.Application.Services.Interfaces;

namespace Resume.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize]
    public class AboutMeController : Controller
    {
        private readonly IAboutMeService _aboutMeService;

        public AboutMeController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
            
        }
        public async Task<IActionResult> Index()
        {
            
            return View(await _aboutMeService.GetAboutMeAdminDTOAsync());
        }

        public async Task<IActionResult> Edit()
        {
            return View(await _aboutMeService.GetAboutMeAdminDTOAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AboutMeAdminDTO aboutMeAdminDTO)
        {
            await _aboutMeService.EditAboutMeAdminDTOAsync(aboutMeAdminDTO);
            return View();
        }

    }
}
