using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class TraineeController : Controller
    {
        ITraineeRepository train;
        public TraineeController(ITraineeRepository c)
        {
            train = c;
        }
        public IActionResult Index()
        {
            List<TraineeViewModel> tvm = new List<TraineeViewModel>();
            List<Trainee> t = train.GetAll();
            foreach (Trainee trinee in t)
            {
                TraineeViewModel tt = new TraineeViewModel()
                {
                    Gender = trinee.Gender,
                    CoachID = trinee.CoachID,
                    ClassID = trinee.ClassID,
                    MembershipTypeID = trinee.MembershipTypeID,
                    DietPlanID = trinee.DietPlanID,
                    DOB = trinee.DOB,
                    Email = trinee.Email,
                    FullName = trinee.FullName,
                    JoinDate = trinee.JoinDate,
                    Phone = trinee.Phone
                };
                tvm.Add(tt);
            }
            return View(tvm);
        }

        public IActionResult MyData()
        {
            string ret = (User.Claims.FirstOrDefault(c => c.Type == "Email")).Value;
            Trainee trinee = train.GetAll().FirstOrDefault(c => c.Email ==ret);
            TraineeViewModel tt = new TraineeViewModel()
            {
                Gender = trinee.Gender,
                CoachID = trinee.CoachID,
                ClassID = trinee.ClassID,
                MembershipTypeID = trinee.MembershipTypeID,
                DietPlanID = trinee.DietPlanID,
                DOB = trinee.DOB,
                Email = trinee.Email,
                FullName = trinee.FullName,
                JoinDate = trinee.JoinDate,
                Phone = trinee.Phone
            };
            return View(tt);
        }
    }
}
