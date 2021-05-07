using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Models
{
    public class AppUser : IdentityUser
    {   
        public bool IsAdmin { get; set; }
    }
}
