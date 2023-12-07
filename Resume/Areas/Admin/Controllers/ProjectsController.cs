using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Site;
using Resume.Application.Services.Interfaces;

namespace Resume.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectsAdminDTO projectsAdminDTO)
        {
            await _projectsService.Create(projectsAdminDTO);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {

            return View(await _projectsService.GetProjectAdminDTOAsync(id));
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(ProjectsAdminDTO projectsAdminDTO)
        {
            await _projectsService.Edit(projectsAdminDTO);

			return RedirectToAction("Index");
		}

        public async Task<IActionResult> Details(int id)
        {
           
            return View(await _projectsService.GetProjectAdminDTOAsync(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            
            return View(await _projectsService.GetProjectAdminDTOAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ProjectsAdminDTO projectsAdminDTO)
        {
            await _projectsService.Delete(projectsAdminDTO.ID);
			return RedirectToAction("Index");
		}

    }
}
