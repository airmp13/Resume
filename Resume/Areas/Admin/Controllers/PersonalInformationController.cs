using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities;

namespace Resume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonalInformationController : Controller
    {
        private readonly IPersonalInformationService _personalInformationService;
        public PersonalInformationController(IPersonalInformationService personalInformationService)
        {
            _personalInformationService = personalInformationService;
        }
        public async Task<IActionResult> Index()
        {
            
            return View(await _personalInformationService.GetPersonalInformationAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return View(await _personalInformationService.GetPersonalInformationAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PersonalInformation personalInformation)
        {
            await _personalInformationService.EditPersonalInformationAsync(personalInformation);
            return View();
        }
    }
}
