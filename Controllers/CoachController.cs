using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class CoachController : Controller
    {
        ICoachRepository coach;
        public CoachController(ICoachRepository c)
        {
            coach = c;
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            if(User.IsInRole("Admin"))
                return RedirectToAction("AllCoaches");
            if (!User.IsInRole("Coach"))
                return RedirectToAction("Index","Home");
            string ret = (User.Claims.FirstOrDefault(c => c.Type == "Email"))?.Value;
            Coach co = coach.GetAll().FirstOrDefault(c => c.Email == ret);
            CoachViewModel tt = new CoachViewModel()
            {
                FullName = co.FullName,
                Email = co.Email,
                Gender = co.Gender,
                PhoneNumber = co.PhoneNumber,
                Specialization = co.Specialization,
                HireDate = co.HireDate,
                Salary = co.Salary,
                Experience = co.Experience,
                Image = co.Image,
                Certification = co.Certification,
                Trainees = co.Trainees,
                WorkOutPrograms = co.WorkOutPrograms,
            };
            return View(tt);

        }
        public IActionResult AllCoaches()
        {
            if (!User.IsInRole("Admin"))
                return RedirectToAction("Index", "Home");
            List<Coach> All = coach.GetAll();
            List<CoachViewModel> coaches = new List<CoachViewModel>();
            foreach (var co in All)

            {
                CoachViewModel tt = new CoachViewModel()
                {
                    FullName = co.FullName,
                    Email = co.Email,
                    Gender = co.Gender,
                    PhoneNumber = co.PhoneNumber,
                    Specialization = co.Specialization,
                    HireDate = co.HireDate,
                    Salary = co.Salary,
                    Experience = co.Experience,
                    Image = co.Image,
                    Certification = co.Certification,
                    Trainees = co.Trainees,
                    WorkOutPrograms = co.WorkOutPrograms,
                };
                coaches.Add(tt);
            }
       
            return View(coaches);
        }

        //Edit current coach

        //Edit(id)

    }
}
