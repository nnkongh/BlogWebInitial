namespace BlogWeb.Models
{
    public class UserProfile
    {
        public string UserName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
