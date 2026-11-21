using Microsoft.EntityFrameworkCore;
using MathSpace.Core.Interfaces;
using MathSpace.Core.Models;
using MathSpace.Infrastructure.Data;

namespace MathSpace.Infrastructure.Repositories;

public class MathTopicRepository : IMathTopicRepository
{
    private readonly AppDbContext _context;

    public MathTopicRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<MathTopic>> GetAllAsync()
    {
        return await _context.MathTopics.ToListAsync();
    }

    public async Task<MathTopic?> GetByIdAsync(int id)
    {
        return await _context.MathTopics.FindAsync(id);
    }

    public async Task AddAsync(MathTopic topic)
    {
        await _context.MathTopics.AddAsync(topic);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MathTopic topic)
    {
        _context.MathTopics.Update(topic);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var topic = await _context.MathTopics.FindAsync(id);

        if (topic != null)
        {
            _context.MathTopics.Remove(topic);
            await _context.SaveChangesAsync();
        }
    }
}
