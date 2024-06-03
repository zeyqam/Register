using Educal_PB101.Models;
using Educal_PB101.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Educal_PB101.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            string hashData = Guid.NewGuid().ToString();
            ViewBag.Hash = hashData;
            if (id == null) return BadRequest();


            Course course = await _courseService.GetCourseByIdAsync((int)id);
            if (course == null) return NotFound();
            return View(course);
        }
    }
    
}
