using Microsoft.EntityFrameworkCore;
using MathSpace.Core.Interfaces;
using MathSpace.Core.Models;
using MathSpace.Infrastructure.Data;

namespace MathSpace.Infrastructure.Repositories;

public class SolutionRepository : ISolutionRepository
{
    private readonly AppDbContext _context;

    public SolutionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Solution>> GetAllAsync()
    {
        return await _context.Solutions
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync();
    }

    public async Task<Solution?> GetByIdAsync(int id)
    {
        return await _context.Solutions.FindAsync(id);
    }

    public async Task AddAsync(Solution solution)
    {
        await _context.Solutions.AddAsync(solution);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var solution = await _context.Solutions.FindAsync(id);

        if (solution != null)
        {
            _context.Solutions.Remove(solution);
            await _context.SaveChangesAsync();
        }
    }
}
