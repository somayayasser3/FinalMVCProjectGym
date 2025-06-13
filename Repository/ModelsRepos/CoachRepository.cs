using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Repository.ModelsRepos
{
    public class CoachRepository : ICoachRepository
    {
        private readonly GymManagementContext _context;

        public CoachRepository(GymManagementContext context)
        {
            _context = context;
        }

        public Coach GetById(int id)
        {
            return _context.Coaches
                .Include(c => c.WorkOutPrograms)
                .Include(c => c.Trainees)
                .FirstOrDefault(c => c.ID == id);
        }

        public List<Coach> GetAll()
        {
            return _context.Coaches
                .Include(c => c.WorkOutPrograms)
                .Include(c => c.Trainees)
                .ToList();
        }

        public void Add(Coach entity)
        {
            _context.Coaches.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Coach entity)
        {
            _context.Coaches.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Coaches.Find(id);
            if (entity != null)
            {
                _context.Coaches.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
