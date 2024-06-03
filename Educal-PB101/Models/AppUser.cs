using Microsoft.AspNetCore.Identity;

namespace Educal_PB101.Models
{
    public class AppUser:IdentityUser
    {
        public string  FullName { get; set; }
    }
}
