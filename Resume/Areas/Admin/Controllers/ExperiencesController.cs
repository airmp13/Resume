using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Site;
using Resume.Application.Services.Interfaces;

namespace Resume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperiencesController : Controller
    {

        private readonly IExperiencesService _experiencesService;

        public ExperiencesController(IExperiencesService experiencesService)
        {
            _experiencesService = experiencesService;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _experiencesService.GetExperiencesAdminDTOListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ExperiencesDTO experiencesDTO)
        {
            await _experiencesService.Create(experiencesDTO);
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _experiencesService.GetExperiencesAdminDTOAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ExperiencesAdminDTO experiencesAdminDTO)
        {
            await _experiencesService.Edit(experiencesAdminDTO);
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _experiencesService.GetExperiencesAdminDTOAsync(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _experiencesService.GetExperiencesAdminDTOAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ExperiencesAdminDTO experiencesAdminDTO)
        {
            await _experiencesService.Delete(experiencesAdminDTO);
            return View();
        }
    }
}
