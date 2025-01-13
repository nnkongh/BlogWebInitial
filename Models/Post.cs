using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BlogWeb.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Content { get; set; } = string.Empty;
        public string? Tag { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }

}
