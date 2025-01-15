using BlogWeb.Database;
using BlogWeb.Models.Authentication;
using BlogWeb.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BlogWeb.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    { 
        private readonly UserManager<User> _userManager;

        public ProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if (userId == null) {
                return RedirectToAction("Login","Account");
            }
            var user = await _userManager.FindByIdAsync(userId);
            var model = new UserViewModel
            {

                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) { 
                return NotFound();
            }
            user.Email = model.Email;
            var updateUser = await _userManager.UpdateAsync(user);
            if (updateUser.Succeeded) {
                ViewBag.Message = "Profile updated successfully";
                return View(model);
            }
            return View(model);
        }
    }
}
