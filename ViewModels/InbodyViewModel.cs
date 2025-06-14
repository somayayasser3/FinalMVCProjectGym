namespace GymManagementSystem.ViewModels
{
    public class InbodyViewModel
    {
            public int ID { get; set; }

            public int TraineeID { get; set; }

            public DateOnly Date { get; set; }

            public decimal Height { get; set; }
            public decimal Weight { get; set; }
            public decimal Fats { get; set; }
            public decimal MuscleMass { get; set; }
            public string? Notes { get; set; }
        }

    }

