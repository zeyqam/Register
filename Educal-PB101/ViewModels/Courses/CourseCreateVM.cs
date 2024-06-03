using System.ComponentModel.DataAnnotations;

namespace Educal_PB101.ViewModels.Courses
{
    public class CourseCreateVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        
        [Required]
        public int LessonCount { get; set; }
        [Required]
       
        public string InstructorName { get; set; }
        
        
        [Required]
        public List<IFormFile> Images { get; set; }
    }
}
