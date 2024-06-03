using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Educal_PB101.ViewModels.Account
{
    public class RegisterVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email is invalid")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
