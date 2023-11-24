using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTOs.Site;
using Resume.Application.Services.Interfaces;

namespace Resume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactMeController : Controller
    {
        private readonly IContactMeService _contactMeService;

        public ContactMeController(IContactMeService contactMeService)
        {
            _contactMeService = contactMeService;
        }
        public async Task<IActionResult> Index()
        {
             
            return View(await _contactMeService.GetContactMesAdminDTO());
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _contactMeService.GetContactMeAdminDTO(id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ContactMeAdminDTO contactMeAdminDTO)
        {
            await _contactMeService.Delete(contactMeAdminDTO);
            return View();
        }

        public async Task<IActionResult> Read(int id)
        {
            return View(await _contactMeService.GetContactMeAdminDTO(id));
        }
    }
}
