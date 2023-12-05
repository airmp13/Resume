using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTOs.Admin;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities;

namespace Resume.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class PersonalInformationController : Controller
    {
        private readonly IPersonalInformationService _personalInformationService;
        public PersonalInformationController(IPersonalInformationService personalInformationService)
        {
            _personalInformationService = personalInformationService;
        }
        public async Task<IActionResult> Index()
        {
            
            return View(await _personalInformationService.GetPersonalInformationAdminDTOAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return View(await _personalInformationService.GetPersonalInformationAdminDTOAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PersonalInformationAdminDTO personalInformationAdminDTO)
        {
            await _personalInformationService.EditPersonalInformationAsync(personalInformationAdminDTO);
            return View();
        }
    }
}
