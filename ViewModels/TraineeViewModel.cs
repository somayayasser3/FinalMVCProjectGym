using System.ComponentModel;

namespace GymManagementSystem.ViewModels
{
    public class TraineeViewModel
    {
        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }


        public string Gender { get; set; }

        public DateOnly? JoinDate { get; set; }

        public DateOnly? DOB { get; set; }

        public int? MembershipTypeID { get; set; }

        public int? DietPlanID { get; set; }

        public int? ClassID { get; set; }

        public int? CoachID { get; set; }
    }
}
