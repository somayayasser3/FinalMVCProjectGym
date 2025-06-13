using Microsoft.AspNetCore.Identity;

namespace GymManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
