using GymApp.ViewModels;
using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymManagementSystem.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepository _traineeRepo;
        private readonly GymManagementContext _context;

        public TraineeController(ITraineeRepository traineeRepo, GymManagementContext context)
        {
            _traineeRepo = traineeRepo;
            _context = context;
        }

        public IActionResult Index()
        {
            var trainees = _traineeRepo.GetAll();
            return View(trainees);
        }

        public IActionResult Details(int id)
        {
            var trainee = _traineeRepo.GetById(id);
            if (trainee == null)
                return NotFound();

            return View(trainee);
        }

        public IActionResult Edit(int id)
        {
            var trainee = _traineeRepo.GetById(id);
            if (trainee == null)
                return NotFound();

            var viewModel = new TraineeEditViewModel
            {
                ID = trainee.ID,
                FullName = trainee.FullName,
                Phone = trainee.Phone,
                Email = trainee.Email,
                Gender = trainee.Gender,
                JoinDate = trainee.JoinDate,
                DOB = trainee.DOB,
                MembershipTypeID = trainee.MembershipTypeID,
                DietPlanID = trainee.DietPlanID,
                CoachID = trainee.CoachID,
                ClassID = trainee.ClassID,

                Classes = new SelectList(_context.Classes, "ID", "Name", trainee.ClassID),
                Coaches = new SelectList(_context.Coaches, "ID", "FullName", trainee.CoachID),
                DietPlans = new SelectList(_context.DietPlans, "ID", "Title", trainee.DietPlanID),
                Memberships = new SelectList(_context.MembershipTypes, "ID", "Name", trainee.MembershipTypeID)
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TraineeEditViewModel viewModel)
        {
            if (id != viewModel.ID)
                return NotFound();

            if (!ModelState.IsValid)
            {
                viewModel.Classes = new SelectList(_context.Classes, "ID", "Name", viewModel.ClassID);
                viewModel.Coaches = new SelectList(_context.Coaches, "ID", "FullName", viewModel.CoachID);
                viewModel.DietPlans = new SelectList(_context.DietPlans, "ID", "Title", viewModel.DietPlanID);
                viewModel.Memberships = new SelectList(_context.MembershipTypes, "ID", "Name", viewModel.MembershipTypeID);

                return View(viewModel);
            }

            var trainee = new Trainee
            {
                ID = viewModel.ID,
                FullName = viewModel.FullName,
                Phone = viewModel.Phone,
                Email = viewModel.Email,
                Gender = viewModel.Gender,
                JoinDate = viewModel.JoinDate,
                DOB = viewModel.DOB,
                MembershipTypeID = viewModel.MembershipTypeID,
                DietPlanID = viewModel.DietPlanID,
                ClassID = viewModel.ClassID,
                CoachID = viewModel.CoachID
            };

            _traineeRepo.Update(trainee);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult InBodyDetails(int id)
        {
            var trainee = _traineeRepo.GetById(id);
            if (trainee == null || trainee.InBodyTests == null)
                return NotFound();

            ViewBag.TraineeName = trainee.FullName;
            return View(trainee.InBodyTests.ToList());
        }

        public IActionResult DietPlanDetails(int id)
        {
            var trainee = _traineeRepo.GetById(id);
            if (trainee == null || trainee.DietPlan == null)
                return NotFound();

            ViewBag.TraineeName = trainee.FullName;
            return View(trainee.DietPlan);
        }
    }
}
