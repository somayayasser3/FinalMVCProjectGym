using GymManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace GymApp.ViewModels

{
    
        public class TraineeEditViewModel
        {
        public int ID { get; set; }

        [Required(ErrorMessage = " name required")]
        [StringLength(100, ErrorMessage = "max 100" )]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [StringLength(20, ErrorMessage = "max 20 ")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "not valid")]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Gender")]
        [RegularExpression("^(M|F)?$", ErrorMessage = "اختر M أو F فقط")]
        public string Gender { get; set; }

        [Display(Name = "Join Date ")]
        [DataType(DataType.Date)]
        public DateOnly? JoinDate { get; set; }

        [Display(Name = " DOB")]
        [DataType(DataType.Date)]
        public DateOnly? DOB { get; set; }

        [Display(Name = " Subscription")]
        [Required(ErrorMessage = "Subscription Required")]
        public int MembershipTypeID { get; set; }

        [Display(Name = "Diet Plan")]
        [Required(ErrorMessage = "DietPlan Required")]
        public int? DietPlanID { get; set; }

        [Display(Name = "Coach")]
        [Required(ErrorMessage = " Coach Required")]
        public int CoachID { get; set; }

        [Display(Name = " Class")]
        [Required(ErrorMessage = "Class Required ")]
        public int ClassID { get; set; }

        public SelectList? Classes { get; set; }
        public SelectList? Coaches { get; set; }
        public SelectList? DietPlans { get; set; }
        public SelectList? Memberships { get; set; }
    }
}

