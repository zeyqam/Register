using Educal_PB101.Data;
using Educal_PB101.Models;
using Educal_PB101.Services.Interfaces;
using Educal_PB101.ViewModels.Courses;
using Microsoft.EntityFrameworkCore;

namespace Educal_PB101.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public  async Task CreateAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async  Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.Include(m=>m.CourseImages).ToListAsync();
        }

        

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }
    

        public async Task<int> GetCountAsync()
        {
            return await _context.Courses.CountAsync();
        }

        public  IEnumerable<CourseVM> GetMappeDatas(IEnumerable<Course> courses)
        {
            return courses.Select(m => new CourseVM
            {
                Id = m.Id,
                Name = m.Name,
                Price = m.Price,
                Description = m.Description,
                CategoryName = m.Category.Name,
                MainImage = m.CourseImages?.FirstOrDefault(m => m.IsMain)?.Name


            });
        }

        public async Task<Course> GetCourseByIdAsync(int? id)
        {
            return await _context.Courses.Where(m => m.Id == id)
                                                 .Include(m => m.Category)
                                                 .Include(m => m.CourseImages)
                                                 .FirstOrDefaultAsync();
        }

        public async  Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _context.Courses.Include(m => m.CourseImages).ToListAsync();
        }
    }
}
