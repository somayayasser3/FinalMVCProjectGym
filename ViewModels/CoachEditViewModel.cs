using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.ViewModels
{
    public class CoachEditViewModel
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }
        public int? Experience { get; set; }

        public string? Certification { get; set; }

    }
}
