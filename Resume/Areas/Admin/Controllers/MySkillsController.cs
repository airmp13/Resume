using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Site;
using Resume.Application.Services.Interfaces;

namespace Resume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MySkillsController : Controller
    {

        private readonly IMySkillsService _mySkillsService;

        public MySkillsController(IMySkillsService mySkillsService)
        {
            _mySkillsService = mySkillsService;
        }

        public async Task<IActionResult> Index()
        {
            List<MySkillsAdminDTO> mySkillsAdminDTO0 = await _mySkillsService.GetGradedMySkillsAdminDTOListAsync(0);
            mySkillsAdminDTO0.AddRange(await _mySkillsService.GetGradedMySkillsAdminDTOListAsync(1));


            return View(mySkillsAdminDTO0);
        }

        public async Task<IActionResult> GradeZero()
        {
            
            return View(await _mySkillsService.GetGradedMySkillsAdminDTOListAsync(0));
        }

        public async Task<IActionResult> GradeOne()
        {
            return View(await _mySkillsService.GetGradedMySkillsAdminDTOListAsync(1));
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MySkillsDTO MySkillsDTO)
        {
            await _mySkillsService.Create(MySkillsDTO);
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _mySkillsService.GetMySkillsAdminDTOAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MySkillsAdminDTO MySkillsAdminDTO)
        {
            await _mySkillsService.Edit(MySkillsAdminDTO);
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _mySkillsService.GetMySkillsAdminDTOAsync(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _mySkillsService.GetMySkillsAdminDTOAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(MySkillsAdminDTO MySkillsAdminDTO)
        {
            await _mySkillsService.Delete(MySkillsAdminDTO);
            return View();
        }
    }
}
