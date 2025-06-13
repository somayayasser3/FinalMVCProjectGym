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
        public IActionResult Index()
        {
            List<CoachViewModel> tvm = new List<CoachViewModel>();
            List<Coach> t = coach.GetAll();
            foreach (Coach co in t)
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
                    Certification  =co.Certification
                };
                tvm.Add(tt);
            }
            return View(tvm);
        }

        public IActionResult MyData()
        {
            string ret = (User.Claims.FirstOrDefault(c => c.Type == "Email")).Value;
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
                Certification = co.Certification
            };
            return View(tt);
        }
    }
}
