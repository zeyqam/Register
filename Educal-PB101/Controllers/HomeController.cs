
using Educal_PB101.Models;
using Educal_PB101.Services.Interfaces;
using Educal_PB101.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Educal_PB101.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICourseService _courseService;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(ICategoryService categoryService, 
                              ICourseService courseService,UserManager<AppUser> userManager)
        {
            _categoryService = categoryService;
            _courseService = courseService;
            _userManager = userManager;

        }


        public async Task<IActionResult> Index()
        {
            HomeVM model = new()
            {
                Categories=await _categoryService.GetAllAsync(),
                Courses=await _courseService.GetAllAsync()
            };
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                model.UserFullName = user?.FullName;
                model.IsAuthenticated = true;
            }
            return View(model);
        }
    }
}