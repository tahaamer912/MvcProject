using Microsoft.EntityFrameworkCore;
using MVCProject.Contexts;
using MVCProject.Entities;
using MVCProject.Repositories.Interfaces;

namespace MVCProject.Repositories.Classes
{
    public class PlanRepository : IPlanRepositoty
    {
        private readonly GymDbContext  _dbcontext;
        public PlanRepository(GymDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            
        }
        public async Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbcontext.Plans.AsNoTracking().ToListAsync(ct);
        }

        public async Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbcontext.Plans.FindAsync(new object[] { id }, ct);
        }

        public async Task<int> UpdateAsync(CancellationToken ct = default)
        {
            try
            {
                return await _dbcontext.SaveChangesAsync(ct);

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"{ex}");
                return 0;
            }
        }
    }
}
