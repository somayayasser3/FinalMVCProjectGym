using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Repository.ModelsRepos
{
    public class InBodyTestRepository : IInBodyTestRepository
    {
        private readonly GymManagementContext _context;

        public InBodyTestRepository(GymManagementContext context)
        {
            _context = context;
        }

        public InBodyTest GetById(int id)
        {
            return _context.InBodyTests
                .Include(i => i.Trainee)
                .FirstOrDefault(i => i.ID == id);
        }

        public List<InBodyTest> GetAll()
        {
            return _context.InBodyTests
                .Include(i => i.Trainee)
                .ToList();
        }

        public void Add(InBodyTest entity)
        {
            _context.InBodyTests.Add(entity);
            _context.SaveChanges();
        }

        public void Update(InBodyTest entity)
        {
            _context.InBodyTests.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.InBodyTests.Find(id);
            if (entity != null)
            {
                _context.InBodyTests.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
