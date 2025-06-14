using GymManagementSystem.Models;

namespace GymManagementSystem.Repository.Interfaces
{
    public interface ITraineeRepository : IRepository<Trainee>
    {
        public Trainee GetByMail(string mail);
    }
}
