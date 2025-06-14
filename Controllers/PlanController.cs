using GymApp.Repository.ModelsRepos;
using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class PlanController : Controller
    {
        ITraineeRepository traineerepo;
        IDietPlanRepository repo;
        public PlanController(IDietPlanRepository r , ITraineeRepository trainer)
        {
            this.repo = r;
            this.traineerepo = trainer;
        }

        // show each trainee's plan by coach in profile 
        public IActionResult Index(int traineeId)
        {
            var trainee = traineerepo.GetById(traineeId);

            if (trainee == null) return NotFound();

            var dietPlan = trainee.DietPlan;

            ViewBag.TraineeId = traineeId;
            return View(dietPlan); 
        }


        [HttpPost]
        public IActionResult Update(DietPlan updatedPlan)
        {
            if (!ModelState.IsValid)
                return View("Index", updatedPlan); 

            var existingPlan = repo.GetById(updatedPlan.ID);
            if (existingPlan == null) return NotFound();

            existingPlan.Title = updatedPlan.Title;
            existingPlan.Description = updatedPlan.Description;
            existingPlan.CreatedAt = DateTime.Now;

            repo.Update(existingPlan); 

            return RedirectToAction("Index","Coach");
        }
        
    }
}
