using BlogWeb.Models;
using BlogWeb.Models.Pagination;
using BlogWeb.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace BlogWeb.Repository.PostRepo
{
    public interface IPostRepository
    {
        IQueryable<PostViewModel> GetPostQuery(string Search);
        Task<Pager<PostViewModel>> GetAllPost(string Search, int page, int pageSize);
        Task<SelectList> GetTagAsync();
        Task<Post?> GetPostByIdAsync(int id);
        Task<Post?> DeletePostAsync(int id);
        Task<Post?> UpdatePostAsync(Post post, int id);
        Task<Post> CreatePostAsync(Post post);
        //Task<IEnumerable<Post>> GetPostsAsync();
    }
}