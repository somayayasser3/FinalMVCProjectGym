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
        IClassRepository classRepo;
        ICoachRepository coachRepo;

        public TraineeController(ITraineeRepository traineeRepo, ICoachRepository coach, GymManagementContext context , IClassRepository Classrepo)
        {
            _traineeRepo = traineeRepo;
            _context = context;
            this.classRepo = Classrepo;
            coachRepo = coach;
        }
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var trainees = _traineeRepo.GetAll();
                return View(trainees);
            }

            if (User.IsInRole("Coach"))
            {
                string ret = (User.Claims.FirstOrDefault(c => c.Type == "Email"))?.Value;

                Coach c = coachRepo.GetByEmail(ret);
                    return View(c.Trainees);
            }

            else
            {
                string ret = (User.Claims.FirstOrDefault(c => c.Type == "Email"))?.Value;
                List<Trainee> l = new List<Trainee>();
                l.Add(_traineeRepo.GetByMail(ret));
                //return View(l);
                return RedirectToAction("Details",new { id = _traineeRepo.GetByMail(ret).ID });
            }

             

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
      
        [Route("Trainee/EditClass/{traineeId}")]
        public IActionResult EditClass(int traineeId)
        {
            var trainee = _traineeRepo.GetById(traineeId);
            if (trainee == null) return NotFound();

            var allClasses = classRepo.GetAll(); 

            var vm = new TraineeClassViewModel
            {
                TraineeId = trainee.ID,
                SelectedClassId = trainee.ClassID,
                AvailableClasses = allClasses
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Trainee/EditClass/{traineeId}")]
        public IActionResult EditClass(TraineeClassViewModel model)
        {
            var trainee = _traineeRepo.GetById(model.TraineeId);
            if (trainee == null) return NotFound();

            trainee.ClassID = model.SelectedClassId;
            _traineeRepo.Update(trainee);

            return RedirectToAction("Index", "Trainee");
        }
        [Route("Trainee/ManageInBody/{traineeId}")]

        public IActionResult ManageInBody(int traineeId)
        {
            var trainee = _traineeRepo.GetById(traineeId);
            if (trainee == null) return NotFound();

            var latestInBody = trainee.InBodyTests
                ?.OrderByDescending(x => x.Date)
                .FirstOrDefault();

            var viewModel = new InbodyViewModel
            {
                ID = latestInBody?.ID ?? 0,
                TraineeID = traineeId,
                Date = latestInBody?.Date ?? DateOnly.FromDateTime(DateTime.Today),
                Height = latestInBody?.Height ?? 0,
                Weight = latestInBody?.Weight ?? 0,
                Fats = latestInBody?.Fats ?? 0,
                MuscleMass = latestInBody?.MuscleMass ?? 0,
                Notes = latestInBody?.Notes
            };

            return View(viewModel); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Trainee/ManageInBody/{traineeId}")]

        public IActionResult ManageInBody(InbodyViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var trainee = _traineeRepo.GetById(model.TraineeID);
            if (trainee == null) return NotFound();

            InBodyTest inBody;

            if (model.ID == 0)
            {
                inBody = new InBodyTest();
                _context.InBodyTests.Add(inBody);
            }
            else
            {
                inBody = _context.InBodyTests.Find(model.ID);
                if (inBody == null) return NotFound();
            }

            inBody.TraineeID = model.TraineeID;
            inBody.Date = model.Date;
            inBody.Height = model.Height;
            inBody.Weight = model.Weight;
            inBody.Fats = model.Fats;
            inBody.MuscleMass = model.MuscleMass;
            inBody.Notes = model.Notes;

            _context.SaveChanges();

            return RedirectToAction("Index", "Trainee");
        }


        //Delete

    }
}
