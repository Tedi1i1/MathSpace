
using Microsoft.EntityFrameworkCore;
using MathSpace.Core.Models;

namespace MathSpace.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<MathTopic> MathTopics { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Solution> Solutions { get; set; }
}

