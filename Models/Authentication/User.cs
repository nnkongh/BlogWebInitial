using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWeb.Models.Authentication
{
    public class User : IdentityUser
    {
        [NotMapped]
        public string Role { get; set; } = string.Empty;
    }
}
