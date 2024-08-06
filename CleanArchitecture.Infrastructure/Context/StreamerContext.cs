using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data.Context;

public class StreamerContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(
                "Server=localhost;Database=CleanArchitecture;user id=SA;password=MyStrongPass123;encrypt=False")
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name })
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Streamer>()
            .HasMany<Video>()
            .WithOne(m => m.Streamer)
            .HasForeignKey(x => x.StreamerId)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Video>()
            .HasMany(p => p.Actors)
            .WithMany(t => t.Videos)
            .UsingEntity<VideoActor>(pt => pt.HasKey(e => new { e.ActorId, e.VideoId }));
    }

    public DbSet<Streamer>? Streamers { get; set; }
    public DbSet<Video>? Videos { get; set; }
}