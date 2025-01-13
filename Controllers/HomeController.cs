using BlogWeb.Models;
using BlogWeb.Models.Pagination;
using BlogWeb.Models.ViewModel;
using BlogWeb.Repository.PostRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace BlogWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepo;

        public HomeController(ILogger<HomeController> logger, IPostRepository postRepo)
        {
            _logger = logger;
            _postRepo = postRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string searchString, int pageIndex = 1, int pageSize = 5)
        {
            var pager = await _postRepo.GetAllPost(searchString, pageIndex, pageSize);
            return View(pager);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
