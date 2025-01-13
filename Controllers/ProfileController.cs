using BlogWeb.Models;
using BlogWeb.Models.Authentication;
using BlogWeb.Repository.PostRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogWeb.Controllers
{
    //[Authorize]
    //public class ProfileController : Controller
    //{
    //    private readonly UserManager<User> _user;
    //    private readonly RoleManager<User> _role;

    //    public ProfileController(UserManager<User> user, RoleManager<User> role) {
    //        _user = user;
    //        _role = role;
    //    }
    //    public async Task<IActionResult> Index()
    //    {
    //        var user = await _user.GetUserAsync(User);
    //        if (user == null)
    //        {
    //            return NotFound();
    //        }
    //        var model = new UserProfile
    //        {
    //            UserName = user.UserName,
    //            Email = user.Email,
                
    //        };
    //        return View(model);
    //    }
    //}
}
