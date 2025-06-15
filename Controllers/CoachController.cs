using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class CoachController : Controller
    {
        ICoachRepository coachrepo;
        public CoachController(ICoachRepository c)
        {
            coachrepo = c;
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
            Coach co = coachrepo.GetAll().FirstOrDefault(c => c.Email == ret);
            CoachViewModel tt = new CoachViewModel()
            {
                ID  = co.ID,
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
            List<Coach> All = coachrepo.GetAll();
            List<CoachViewModel> coaches = new List<CoachViewModel>();
            foreach (var co in All)

            {
                CoachViewModel tt = new CoachViewModel()
                {
                    ID = co.ID,
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
        [Route("Coach/Edit/{id}")]

        public IActionResult Edit(int id)
        {
            var coach = coachrepo.GetById(id);
            if (coach == null) return NotFound();

            var viewModel = new CoachEditViewModel
            {
                ID = coach.ID, 
                FullName = coach.FullName,
                PhoneNumber = coach.PhoneNumber,
                Email = coach.Email,
                Gender = coach.Gender,
                Specialization = coach.Specialization,
                Experience = coach.Experience,
                Certification = coach.Certification
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSave(CoachEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var coach = coachrepo.GetById(model.ID);
            if (coach == null) return NotFound();

            coach.FullName = model.FullName;
            coach.Email = model.Email;
            coach.PhoneNumber = model.PhoneNumber;
            coach.Gender = model.Gender;
            coach.Specialization = model.Specialization;
            coach.Experience = model.Experience;
            coach.Certification = model.Certification;

            coachrepo.Update(coach);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id )
        {
            if (id == null) return NotFound();
            coachrepo.Delete(id);
            return RedirectToAction("AllCoaches");
        }
    }
}
