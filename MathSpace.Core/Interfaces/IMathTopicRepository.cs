using MathSpace.Core.Models;
namespace MathSpace.Core.Interfaces;

public interface IMathTopicRepository
{
    Task<List<MathTopic>> GetAllAsync();

    Task<MathTopic?> GetByIdAsync(int id);

    Task AddAsync(MathTopic topic);

    Task UpdateAsync(MathTopic topic);

    Task DeleteAsync(int id);
}