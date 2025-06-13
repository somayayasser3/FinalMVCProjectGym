using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Repository.ModelsRepos
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly GymManagementContext _context;

        public TraineeRepository(GymManagementContext context)
        {
            _context = context;
        }

        public Trainee GetById(int id)
        {
            return _context.Trainees
                .Include(t => t.Coach)
                .Include(t => t.Class)
                .Include(t => t.DietPlan)
                .Include(t => t.MembershipType)
                .Include(t => t.InBodyTests)
                .FirstOrDefault(t => t.ID == id);
        }

        public List<Trainee> GetAll()
        {
            return _context.Trainees
                .Include(t => t.Coach)
                .Include(t => t.Class)
                .Include(t => t.DietPlan)
                .Include(t => t.MembershipType)
                .Include(t => t.InBodyTests)
                .ToList();
        }

        public void Add(Trainee entity)
        {
            _context.Trainees.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Trainee entity)
        {
            _context.Trainees.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Trainees.Find(id);
            if (entity != null)
            {
                _context.Trainees.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
