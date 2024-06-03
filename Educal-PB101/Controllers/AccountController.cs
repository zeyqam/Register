using Educal_PB101.Models;
using Educal_PB101.ViewModels.Account;
using Educal_PB101.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Educal_PB101.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, 
                                 SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [HttpGet]
        public async Task< IActionResult> SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegisterVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = new()
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.UserName
            };
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                return View();
            }

            await _signInManager.SignInAsync(user,  false);
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        
        
    }
}
