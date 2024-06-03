namespace Educal_PB101.ViewModels.Courses
{
    public class CourseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int LessonCount { get; set; }
        public string InstructorName { get; set; }
        public string CategoryName { get; set; }
        public string MainImage { get; set; }
    }
}
