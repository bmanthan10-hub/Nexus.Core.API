using Microsoft.AspNetCore.Identity;

namespace Nexus.Core.API.Models
{
    // Extends IdentityUser to add custom fields if needed
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}