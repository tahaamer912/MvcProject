using System.Linq.Expressions;
using MVCProject.Entities;

namespace MVCProject.Repositories.Interfaces
{
    public interface IMembershipRepository
    {
        Task<bool>AnyAsync(Expression<Func<Membership, bool>> predicate, CancellationToken ct = default);
    }
}
