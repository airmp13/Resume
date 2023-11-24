using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Site;
using Resume.Application.Services.Interfaces;

namespace Resume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationsController : Controller
    {

        private readonly IEducationService _EducationService;

        public EducationsController(IEducationService EducationService)
        {
            _EducationService = EducationService;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _EducationService.GetEducationsAdminDTOListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EducationsDTO EducationDTO)
        {
            await _EducationService.Create(EducationDTO);
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _EducationService.GetEducationsAdminDTOAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EducationsAdminDTO EducationsAdminDTO)
        {
            await _EducationService.Edit(EducationsAdminDTO);
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _EducationService.GetEducationsAdminDTOAsync(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _EducationService.GetEducationsAdminDTOAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EducationsAdminDTO EducationsAdminDTO)
        {
            await _EducationService.Delete(EducationsAdminDTO);
            return View();
        }
    }
}
