using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data.Context;

public class StreamerContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=CleanArchitecture;user id=SA;password=MyStrongPass123;encrypt=False")
        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name })
        .EnableSensitiveDataLogging();
    }

    public DbSet<Streamer>? Streamers { get; set; }
    public DbSet<Video>? Videos { get; set; }
}