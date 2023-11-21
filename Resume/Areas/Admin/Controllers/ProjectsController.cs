using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTOs.Admin;
using Resume.Application.Services.Interfaces;

namespace Resume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectsController : Controller
    {
        private readonly IProjectsService _projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
            
        }
        public async Task<IActionResult> Index()
        {
            
            return View(await _projectsService.GetProjectsAdminDTOListAsync());
        }

        public async Task<IActionResult> Edit(int id)
        {

            return View(await _projectsService.GetProjectAdminDTOAsync(id));
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(ProjectsAdminDTO projectsAdminDTO)
        {

            return View() ;
        }

    }
}
