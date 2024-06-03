using System.ComponentModel.DataAnnotations;

namespace Educal_PB101.ViewModels.Categories
{
    public class CategoryCreateVM
    {
        [Required(ErrorMessage ="Input can't be empty")]
        [StringLength(20)]
        public string Name  { get; set; }
        
        

       
        
    }
}
