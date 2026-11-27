using MVCProject.Entities;

namespace MVCProject.Repositories.Interfaces
{
    public interface IPlanRepositoty
    {
        Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default);
      Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<int> UpdateAsync(CancellationToken ct = default);
    }

}
