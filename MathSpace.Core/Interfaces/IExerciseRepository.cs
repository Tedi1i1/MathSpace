using MathSpace.Core.Models;

namespace MathSpace.Core.Interfaces;

public interface IExerciseRepository
{
    Task<List<Exercise>> GetAllAsync();

    Task<Exercise?> GetByIdAsync(int id);

    Task AddAsync(Exercise exercise);

    Task UpdateAsync(Exercise exercise);

    Task DeleteAsync(int id);
}
