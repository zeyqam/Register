using Educal_PB101.Models;
using Educal_PB101.ViewModels.Courses;

namespace Educal_PB101.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course> GetCourseByIdAsync(int? id);
        Task<Course> GetByIdAsync(int id);
        
        IEnumerable<CourseVM> GetMappeDatas(IEnumerable<Course> courses);
       
        Task<int> GetCountAsync();
        Task CreateAsync(Course course);
    }
}
