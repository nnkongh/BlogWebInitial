using System.ComponentModel.DataAnnotations;

namespace BlogWeb.Models.Account
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Compare("Password",ErrorMessage ="Mật khẩu không khớp")]
        public string ConfirmPassword {  get; set; } = string.Empty;
    }
}
