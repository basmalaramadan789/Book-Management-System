using Microsoft.AspNetCore.Identity;

namespace assigment.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
          
}
