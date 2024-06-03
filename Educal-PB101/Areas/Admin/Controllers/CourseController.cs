using Educal_PB101.Helpers.Extensions;
using Educal_PB101.Models;
using Educal_PB101.Services.Interfaces;
using Educal_PB101.ViewModels.Courses;
using Microsoft.AspNetCore.Mvc;

namespace Educal_PB101.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICourseService _courseService;
        private readonly IWebHostEnvironment _env;
        public CourseController( ICategoryService categoryService, 
                                 ICourseService courseService, 
                                 IWebHostEnvironment env)
        {
            _categoryService = categoryService;
            _courseService = courseService;
            _env = env;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await _categoryService.GetAllSelectedAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateVM request)
        {
            ViewBag.categories = await _categoryService.GetAllSelectedAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }


            foreach (var item in request.Images)
            {
                if (!item.CheckFileSize(500))
                {
                    ModelState.AddModelError("Images", "Image size must be 500 kb");
                    return View();
                }
                if (!item.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Images", "File type must be fyle type");
                    return View();
                }
            }
            List<CourseImage> images = new();


            foreach (var item in request.Images)
            {
                string fileName = $"{Guid.NewGuid()}-{item.FileName}";
                string path = _env.GenerateFilePath("img", fileName);
                await item.SaveFileLocalAsync(path);
                images.Add(new CourseImage { Name = fileName });
            }

            images.FirstOrDefault().IsMain = true;
            Course course = new Course()
            {
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Price = decimal.Parse(request.Price),
                CourseImages = images

            };

            await _courseService.CreateAsync(course);
            return RedirectToAction(nameof(Index));

        }
    }
}
