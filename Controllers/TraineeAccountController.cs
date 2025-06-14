using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace GymManagementSystem.Controllers
{
    public class TraineeAccountController : Controller
    {
        ITraineeRepository trainee;
        IMembershipTypeRepository membershipType;
        ICoachRepository coach;
        IClassRepository classs;
        IDietPlanRepository dietPlan;

        public UserManager<ApplicationUser> userManager { get; }
        public SignInManager<ApplicationUser> signInManager { get; }
        public TraineeAccountController(ITraineeRepository repo, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMembershipTypeRepository mem, 
            ICoachRepository coh, IClassRepository clas, IDietPlanRepository diet)
        {
            trainee = repo;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.membershipType = mem;
            this.coach = coh;
            this.classs = clas;
            this.dietPlan = diet;
        }
        public IActionResult Signup()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            TraineeSignupViewModel model = new TraineeSignupViewModel();
            SetListItemsValues(ref model);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(TraineeSignupViewModel userFromReq)
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

                    Trainee t = new Trainee()
                    {

                        FullName = userFromReq.FullName,
                        Phone = userFromReq.Phone,
                        Email = userFromReq.Email,
                        Gender = userFromReq.Gender.ToString(),
                        MembershipTypeID = userFromReq.MembershipType,
                        CoachID = userFromReq.CoachID,
                        DietPlanID = userFromReq.DietPlan,
                        ClassID = userFromReq.ClassID,
                        JoinDate = DateOnly.FromDateTime(DateTime.Today),
                        DOB = userFromReq.DOB,

                    };
                    trainee.Add(t);
                    IdentityResult role = await userManager.AddToRoleAsync(user, "Trainee");
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("Displayname", userFromReq.FullName));
                    claims.Add(new Claim("Role", "Trainee"));
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
        //    ApplicationUser userDB = await userManager.FindByEmailAsync(userFromReq.Email);
        //    if (userDB != null)
        //    {
        //        bool ok = await userManager.CheckPasswordAsync(userDB, userFromReq.Password);
        //        if (ok)
        //        {
        //            // Check if user is actually a Trainee
        //            var isTrainee = await userManager.IsInRoleAsync(userDB, "Trainee");
        //            if (isTrainee)
        //            {
        //                List<Claim> claims = new List<Claim>();
        //                claims.Add(new Claim("Displayname", userDB.DisplayName));
        //                claims.Add(new Claim("Email", userDB.Email));
        //                claims.Add(new Claim("Role", "Trainee"));

        //                await signInManager.SignInWithClaimsAsync(userDB, userFromReq.RememberMe, claims);
        //                return RedirectToAction("Index", "Home");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Access denied. Trainee credentials required.");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Invalid credentials");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Invalid credentials");
        //    }
        //    return View();
        //}
        //public async Task<IActionResult> Logout()
        //{
        //    await signInManager.SignOutAsync();
        //    return RedirectToAction("Login");
        //}

        public void SetListItemsValues(ref TraineeSignupViewModel userFromReq)
        {
            userFromReq.GenderOptions = new List<SelectListItem> {
                new SelectListItem { Value = "M", Text = "Male" },
    new SelectListItem { Value = "F", Text = "Female" }
                };
            userFromReq.MembershipTypes = membershipType.GetAll().Select(
                    m => new SelectListItem
                    {
                        Value = m.ID.ToString(),
                        Text = m.Name.ToString()
                    }
                    ).ToList();

            userFromReq.DietPlanTypes = dietPlan.GetAll().Select(
                    m => new SelectListItem
                    {
                        Value = m.ID.ToString(),
                        Text = m.Title.ToString()
                    }
                    ).ToList();
            userFromReq.Classes = classs.GetAll().Select(
                    m => new SelectListItem
                    {
                        Value = m.ID.ToString(),
                        Text = m.Name.ToString()
                    }
                    ).ToList();
            userFromReq.Coaches = coach.GetAll().Select(
                    m => new SelectListItem
                    {
                        Value = m.ID.ToString(),
                        Text = m.FullName.ToString()
                    }
                    ).ToList();
        }
    }
}
