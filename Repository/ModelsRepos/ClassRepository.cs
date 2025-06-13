using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Repository.ModelsRepos
{
    public class ClassRepository : IClassRepository
    {
        private readonly GymManagementContext _context;

        public ClassRepository(GymManagementContext context)
        {
            _context = context;
        }

        public Class GetById(int id)
        {
            return _context.Classes
                .Include(c => c.Program)
                .Include(c => c.Trainees)
                .FirstOrDefault(c => c.ID == id);
        }

        public List<Class> GetAll()
        {
            return _context.Classes
                .Include(c => c.Program)
                .Include(c => c.Trainees)
                .ToList();
        }

        public void Add(Class entity)
        {
            _context.Classes.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Class entity)
        {
            _context.Classes.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Classes.Find(id);
            if (entity != null)
            {
                _context.Classes.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
