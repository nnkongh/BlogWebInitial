using BlogWeb.Database;
using BlogWeb.Models;
using BlogWeb.Repository.PostRepo;
using Microsoft.EntityFrameworkCore;
using BlogWeb.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using BlogWeb.Models.Pagination;

namespace BlogWeb.Repository.PostRepository
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Post> CreatePostAsync(Post post)
        {
            var newPost = new Post
            {

                Id = post.Id,
                Title = post.Title,
                Tag = post.Tag,
                Content = post.Content,
                CreateAt = DateTime.Now,
            };
            await _context.AddAsync(newPost);
            await _context.SaveChangesAsync();
            return newPost;
        }

        public async Task<Post?> DeletePostAsync(int id)
        {
            var find = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if (find == null) return null;
            _context.Posts.Remove(find);
            await _context.SaveChangesAsync();
            return find;
        }
        public async Task<SelectList> GetTagAsync()
        {
            var tags = await _context.Posts.Select(p => p.Tag).Distinct().ToListAsync();
            return new SelectList(tags);
        }



        public async Task<Post?> GetPostByIdAsync(int id)
        {
            var find = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if (find == null) return null;
            return find;
        }


        public async Task<Post?> UpdatePostAsync(Post post, int id)
        {
            var item = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if (item == null) return null;
            item.Title = post.Title;
            item.Tag = post.Tag;
            item.Content = post.Content;
            item.CreateAt = post.CreateAt;
            await _context.SaveChangesAsync();
            return item;
        }

    
        public IQueryable<PostViewModel> GetPostQuery(string Search)
        {
            var query = _context.Posts.AsQueryable();
            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(p => p.Tag.Contains(Search));
            }
            return query.Select(p => new PostViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                Tag = p.Tag,
                CreateAt = p.CreateAt,
            });
        }
    
        public async Task<Pager<PostViewModel>> GetAllPost(string Search, int page = 1, int pageSize = 10)
        {
            var query = GetPostQuery(Search);
//            var totalItem = await query.CountAsync();

            return await Pager<PostViewModel>.CreateAsync(query, page, pageSize);
        }


    }

}
