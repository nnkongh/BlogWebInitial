using BlogWeb.Models;

namespace BlogWeb.Repository.CommentRepo
{
    public interface ICommentRepository
    {
        Task<Comment> CreateCommentAsync(Comment comment);
        Task<Comment?> DeleteCommentAsync(int id);
        Task<Comment?> UpdateCommentAsync(int id, Comment comment);

    }
}