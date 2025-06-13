using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Repository.ModelsRepos
{
    public class MembershipTypeRepository : IMembershipTypeRepository
    {
        private readonly GymManagementContext _context;

        public MembershipTypeRepository(GymManagementContext context)
        {
            _context = context;
        }

        public MembershipType GetById(int id)
        {
            return _context.MembershipTypes
                .Include(m => m.Trainees)
                .FirstOrDefault(m => m.ID == id);
        }

        public List<MembershipType> GetAll()
        {
            return _context.MembershipTypes
                .Include(m => m.Trainees)
                .ToList();
        }

        public void Add(MembershipType entity)
        {
            _context.MembershipTypes.Add(entity);
            _context.SaveChanges();
        }

        public void Update(MembershipType entity)
        {
            _context.MembershipTypes.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.MembershipTypes.Find(id);
            if (entity != null)
            {
                _context.MembershipTypes.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
