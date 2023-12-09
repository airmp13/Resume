using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTOs.Admin;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities;
using System.Security.Claims;
using DNTCaptcha.Core;

namespace Resume.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ValidateDNTCaptcha(ErrorMessage ="Please Enter Captcha Code!")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO loginDTO)
        {
            if(ModelState.IsValid)
            {
                UserLoginDTO userLoginDTO = await _accountService.UserLogin(loginDTO);
                if (userLoginDTO.PhoneNumber == loginDTO.PhoneNumber && userLoginDTO.Password == loginDTO.Password)
                {
                    var claims = new List<Claim>
                        {
                            new (ClaimTypes.NameIdentifier, userLoginDTO.PhoneNumber.ToString()),
                            new (ClaimTypes.Name, userLoginDTO.PhoneNumber),
                        };

                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(claimIdentity);

                    var authProps = new AuthenticationProperties();
                    authProps.IsPersistent = loginDTO.RememberMe;

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return NotFound();
                }

            }
            
            return View(loginDTO);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

    }
}
