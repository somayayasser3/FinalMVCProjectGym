using GymManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class LogoutController : Controller
    {
        public SignInManager<ApplicationUser> signInManager { get; }
        public LogoutController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
