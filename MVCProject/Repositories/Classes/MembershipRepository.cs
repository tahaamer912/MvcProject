using Microsoft.EntityFrameworkCore;
using MVCProject.Repositories.Interfaces;
using MVCProject.Entities;
using MVCProject.Contexts;
using System.Linq.Expressions;
namespace MVCProject.Repositories.Classes
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly GymDbContext _dbcontext;
        public MembershipRepository(GymDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> AnyAsync(Expression<Func<Membership, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbcontext.Memberships.AnyAsync(predicate, ct);
        }
    }
}
