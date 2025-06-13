using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Repository.ModelsRepos
{
    public class DietPlanRepository : IDietPlanRepository
    {
        private readonly GymManagementContext _context;

        public DietPlanRepository(GymManagementContext context)
        {
            _context = context;
        }

        public DietPlan GetById(int id)
        {
            return _context.DietPlans
                .Include(d => d.Trainees)
                .FirstOrDefault(d => d.ID == id);
        }

        public List<DietPlan> GetAll()
        {
            return _context.DietPlans
                .Include(d => d.Trainees)
                .ToList();
        }

        public void Add(DietPlan entity)
        {
            _context.DietPlans.Add(entity);
            _context.SaveChanges();
        }

        public void Update(DietPlan entity)
        {
            _context.DietPlans.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.DietPlans.Find(id);
            if (entity != null)
            {
                _context.DietPlans.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
