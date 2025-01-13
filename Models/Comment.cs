using Microsoft.Identity.Client;

namespace BlogWeb.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string OwnerCmtId { get; set; } = default!;
    }
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
    public static class CommentMapping
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto()
            {
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
            };
        }
    }
}
