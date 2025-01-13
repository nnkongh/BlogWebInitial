using BlogWeb.Database;
using BlogWeb.Models;
using BlogWeb.Repository.CommentRepo;
using Microsoft.EntityFrameworkCore;

namespace BlogWeb.Repository.CommentRepo
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context) {
            _context = context;
        }
        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteCommentAsync(int id)
        {
            var item = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (item == null)
            {
                return null;
            }
            _context.Comments.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Comment?> UpdateCommentAsync(int id, Comment comment)
        {
            var item = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (item == null)
            {
                return null;
            }
            item.Content = comment.Content;
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
