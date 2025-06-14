using GymManagementSystem.Models;

namespace GymManagementSystem.ViewModels
{
    public class TraineeClassViewModel
    {
        public int TraineeId { get; set; }
        public int SelectedClassId { get; set; }
        public List<Class> AvailableClasses { get; set; }

    }
}
