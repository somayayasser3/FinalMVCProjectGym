 using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class RoleController : Controller
    {
        public RoleManager<IdentityRole> role { get; set; }

        public RoleController(RoleManager<IdentityRole> r)
        {
            role = r;
        }

        public IActionResult AddRole()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel r)
        {
            if (ModelState.IsValid)
            {

                IdentityRole newRole = new IdentityRole
                {
                    Name = r.RoleName,
                };
                IdentityResult res = await role.CreateAsync(newRole);
                if (res.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in res.Errors)
                    ModelState.AddModelError("", item.Description);
            }
            return View("AddRole", r);
        }
    }
}
