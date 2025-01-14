using BlogWeb.Models;
using BlogWeb.Models.ViewModel;
using BlogWeb.Repository.PostRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BlogWeb.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepo;
        private readonly ILogger<PostController> _logger;

        public PostController(IPostRepository postRepo, ILogger<PostController> logger)
        {
            _postRepo = postRepo;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
           
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            var item = await _postRepo.CreatePostAsync(post);
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult UpdatePost()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> UpdatePost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!User.Identity.IsAuthenticated) {
                _logger.LogInformation("Has not been register");
            }
            var item = await _postRepo.UpdatePostAsync(post,id);
            if (item == null) { 
                return View(item);
            }
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var item = await _postRepo.DeletePostAsync(id);
            return RedirectToAction("Index","Home");
        }
      
    }
}
