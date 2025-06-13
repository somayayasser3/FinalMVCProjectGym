using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Repository.ModelsRepos
{
    public class WorkOutProgramRepository : IWorkOutProgramRepository
    {
        private readonly GymManagementContext _context;

        public WorkOutProgramRepository(GymManagementContext context)
        {
            _context = context;
        }

        public WorkOutProgram GetById(int id)
        {
            return _context.WorkOutPrograms
                .Include(p => p.Coach)
                .Include(p => p.Classes)
                .FirstOrDefault(p => p.ID == id);
        }

        public List<WorkOutProgram> GetAll()
        {
            return _context.WorkOutPrograms
                .Include(p => p.Coach)
                .Include(p => p.Classes)
                .ToList();
        }

        public void Add(WorkOutProgram entity)
        {
            _context.WorkOutPrograms.Add(entity);
            _context.SaveChanges();
        }

        public void Update(WorkOutProgram entity)
        {
            _context.WorkOutPrograms.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.WorkOutPrograms.Find(id);
            if (entity != null)
            {
                _context.WorkOutPrograms.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
