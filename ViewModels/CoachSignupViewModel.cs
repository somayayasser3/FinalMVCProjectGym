using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.ViewModels
{
    public class CoachSignupViewModel
    {
        public string FullName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Specialization { get; set; }
        public List<SelectListItem>? SpecializationOptions { get; set; }
        [Display(Name = "Years of experience")]
        public int Experience { get; set; }
        public char Gender { get; set; }
        public List<SelectListItem>? GenderOptions { get; set; }

        public DateOnly JoinDate { get; set; }
    }
}
