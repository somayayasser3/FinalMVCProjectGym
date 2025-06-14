using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class InBodyTestController : Controller
    {
        private readonly IInBodyTestRepository _repo;
        private readonly ITraineeRepository _traineeRepo;

        public InBodyTestController(IInBodyTestRepository repo, ITraineeRepository traineeRepo)
        {
            _repo = repo;
            _traineeRepo = traineeRepo;
        }

        public IActionResult Create(int traineeId)
        {
            ViewBag.TraineeId = traineeId;
            return View(new InBodyTest { Date = DateOnly.FromDateTime(DateTime.Today) });
        }

        [HttpPost]
        public IActionResult Create(InBodyTest test)
        {
            if (!ModelState.IsValid)
                return View(test);

            _repo.Add(test);
            
            return RedirectToAction("Index", "Coach");
        }
    }
}
