namespace Educal_PB101.Models
{
    public class Course:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int LessonCount { get; set; }  
        public double Rating { get; set; }  
        public string InstructorName { get; set; } 
        
        public ICollection<CourseImage> CourseImages { get; set; }
    }
}
