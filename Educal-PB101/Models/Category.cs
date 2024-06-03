namespace Educal_PB101.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        
        public ICollection<Course> Course { get; set; }
    }
}
