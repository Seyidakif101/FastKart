using Microsoft.AspNetCore.Identity;

namespace Abi.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
