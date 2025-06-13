using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.ViewModels
{
    public class TraineeSignupViewModel
    {
        public string FullName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public char Gender { get; set; }
        public List<SelectListItem>? GenderOptions { get; set; }


        public DateOnly JoinDate { get; set; }

        [Display(Name = "Date of birth")]
        public DateOnly DOB { get; set; }

        public int MembershipType { get; set; }
        public List<SelectListItem>? MembershipTypes { get; set; }

        public int DietPlan { get; set; }
        public List<SelectListItem>? DietPlanTypes { get; set; }

        public int ClassID { get; set; }
        public List<SelectListItem>? Classes { get; set; }

        public int CoachID { get; set; }
        public List<SelectListItem>? Coaches { get; set; }
    }
}
