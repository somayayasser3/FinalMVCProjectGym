using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Repository.Interfaces
{
    public interface ICoachRepository : IRepository<Coach>
    {
        public List<Coach> GetMyTarainees();
        public Coach GetByEmail(string mail);
       
    }
}
