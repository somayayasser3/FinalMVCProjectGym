using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GymManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        public UserManager<ApplicationUser> userManager { get; }
        public SignInManager<ApplicationUser> signInManager { get; }
        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Index(LoginViewModel  userFromReq)
        {
            ApplicationUser userDB = await userManager.FindByEmailAsync(userFromReq.Email);
            if (userDB != null)
            {
                bool ok = await userManager.CheckPasswordAsync(userDB, userFromReq.Password);
                if (ok)
                {
                    string role = await userManager.IsInRoleAsync(userDB, "Trainee") ? "Trainee" : "No";
                    if(role == "No")
                    {
                        role = await userManager.IsInRoleAsync(userDB, "Coach") ? "Coach" : "Admin";
                    }
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("Displayname", userDB.DisplayName));
                    claims.Add(new Claim("Email", userDB.Email));
                    claims.Add(new Claim("Role",role));

                    await signInManager.SignInWithClaimsAsync(userDB, userFromReq.RememberMe, claims);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid credentials");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View();
        }
    }
}
