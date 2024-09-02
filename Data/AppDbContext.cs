using BokoSan_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BokoSan_backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<HighScore> HighScores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Level>().HasOne(l => l.Creator).WithMany(p => p.LevelsCreated);
        modelBuilder.Entity<HighScore>().HasOne(hs => hs.Player).WithMany(p => p.HighScores);
        modelBuilder.Entity<HighScore>().HasOne(hs => hs.Level).WithMany(l => l.HighScores);
    }
}
