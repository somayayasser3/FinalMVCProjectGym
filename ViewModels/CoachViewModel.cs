using GymManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagementSystem.ViewModels
{
    public class CoachViewModel
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }

        public DateOnly? HireDate { get; set; }

        public decimal? Salary { get; set; }

        public int? Experience { get; set; }

        public string Image { get; set; }

        public string Certification { get; set; }

        public virtual ICollection<WorkOutProgram> WorkOutPrograms { get; set; } = new List<WorkOutProgram>();
        public virtual ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();

    }
}
