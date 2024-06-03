using Educal_PB101.Models;
using Microsoft.AspNetCore.Identity;

namespace Educal_PB101.ViewModels.Home
{
    public class HomeVM
    {
       
        
       
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Course> Courses { get; set; }
        public string UserFullName { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
