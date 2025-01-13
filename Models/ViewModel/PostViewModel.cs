using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BlogWeb.Models.ViewModel
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? Tag { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public IEnumerable<PostViewModel> Posts { get; set; } = [];
    }
}
