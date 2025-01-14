using BlogWeb.Models;
using BlogWeb.Models.Account;
using BlogWeb.Models.Authentication;
using BlogWeb.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace BlogWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signIn;
      

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signIn)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signIn = signIn;

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);
                if (user == null)
                {
                    return View();
                }

                var password = await _signIn.CheckPasswordSignInAsync(user, model.Password, true);
                if (!password.Succeeded)
                {
                    return View();
                }
                var roles = await _userManager.GetRolesAsync(user);

                var claims = new List<Claim>()
                {
                    new(ClaimTypes.Sid,user.Id),
                    new(ClaimTypes.NameIdentifier,user.Id),
                    new(ClaimTypes.Name,user.UserName),
                    new(ClaimTypes.Email,user.Email),
                };
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index","Home" );

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.UserName,
                };
                var register = await _userManager.CreateAsync(user, model.Password);
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("User"));
                }
                var role = await _userManager.AddToRoleAsync(user, "User");
                if (register.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View(register.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Login");
        }
    }
}
