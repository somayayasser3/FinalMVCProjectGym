using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace GymManagementSystem.Controllers
{
    public class CoachAccountController : Controller
    {
        ICoachRepository coach;
        public UserManager<ApplicationUser> userManager { get; }
        public SignInManager<ApplicationUser> signInManager { get; }

        public CoachAccountController(ICoachRepository repo, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            coach = repo;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Signup()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            CoachSignupViewModel model = new CoachSignupViewModel();
            SetListItemsValues(ref model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(CoachSignupViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser exist = await userManager.FindByEmailAsync(userFromReq.Email);
                if (exist != null)
                {
                    ModelState.AddModelError("Email", "Email already registered");
                    SetListItemsValues(ref userFromReq);
                    return View("Signup", userFromReq);
                }

                ApplicationUser user = new ApplicationUser()
                {
                    Email = userFromReq.Email,
                    UserName = userFromReq.Email,
                    PasswordHash = userFromReq.Password,
                    DisplayName = userFromReq.FullName
                };

                IdentityResult res = await userManager.CreateAsync(user, userFromReq.Password);
                if (res.Succeeded)
                {  
                    Coach c = new Coach()
                    {
                        FullName = userFromReq.FullName,
                        PhoneNumber = userFromReq.Phone,
                        Email = userFromReq.Email,
                        Gender = userFromReq.Gender.ToString(),
                        Specialization = userFromReq.Specialization,
                        HireDate = DateOnly.FromDateTime(DateTime.Today),
                        Experience = userFromReq.Experience,
                    };

                    coach.Add(c);
                    IdentityResult role = await userManager.AddToRoleAsync(user, "Coach");

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("Displayname", userFromReq.FullName));
                    claims.Add(new Claim("Email", userFromReq.Email));
                    claims.Add(new Claim("Role", "Coach"));

                    await signInManager.SignInWithClaimsAsync(user, false, claims);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var item in res.Errors)
                    ModelState.AddModelError("", item.Description);
            }

            SetListItemsValues(ref userFromReq);
            return View(userFromReq);
        }

        //public IActionResult Login()
        //{
        //    if (User.Identity.IsAuthenticated)
        //        return RedirectToAction("Index", "Home");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel userFromReq)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ApplicationUser userDB = await userManager.FindByEmailAsync(userFromReq.Email);
        //        if (userDB != null)
        //        {
        //            bool ok = await userManager.CheckPasswordAsync(userDB, userFromReq.Password);
        //            if (ok)
        //            {
        //                    List<Claim> claims = new List<Claim>();
        //                    claims.Add(new Claim("Displayname", userDB.DisplayName));
        //                    claims.Add(new Claim("Email", userDB.Email));
        //                    claims.Add(new Claim("Role", "Coach"));

        //                    await signInManager.SignInWithClaimsAsync(userDB, userFromReq.RememberMe, claims);
        //                    return RedirectToAction("Index", "Home");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Invalid credentials");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Invalid credentials");
        //        }
        //    }
        //    return View();
        //}

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public void SetListItemsValues(ref CoachSignupViewModel userFromReq)
        {
            userFromReq.GenderOptions = new List<SelectListItem> {
                new SelectListItem { Value = "M", Text = "Male" },
                new SelectListItem { Value = "F", Text = "Female" }
            };

            // You can add more dropdown options here if needed
            // For example, specialization types, certification types, etc.
            userFromReq.SpecializationOptions = coach.GetAll().Select(
                    m => new SelectListItem
                    {
                        Value = m.ID.ToString(),
                        Text = m.Specialization.ToString()
                    }).ToList();
        }
    }
}