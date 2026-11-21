using MathSpace.Core.Models;

namespace MathSpace.Core.Interfaces;

public interface ISolutionRepository
{
    Task<List<Solution>> GetAllAsync();

    Task<Solution?> GetByIdAsync(int id);

    Task AddAsync(Solution solution);

    Task DeleteAsync(int id);
}