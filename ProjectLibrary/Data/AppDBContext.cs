using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Models;

namespace ProjectLibrary.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Calculator> Calculator { get; set; }
        public DbSet<GameStatistics> GameStatistics { get; set; }
        public DbSet<RockPaperSicssorGame> RockPaperScissorGame { get; set; }
        public DbSet<Shape> Shape { get; set; }

        public AppDBContext()
        {
            // en tom konstruktor behövs för att skapa migrations
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=ProjectOneDB;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Calculator>().Property(c => c.MathOperator).HasColumnType("tinyint");
            modelBuilder.Entity<RockPaperSicssorGame>().Property(rps => rps.PlayerChoice).HasColumnType("tinyint");
            modelBuilder.Entity<RockPaperSicssorGame>().Property(rps => rps.ComputerChoice).HasColumnType("tinyint");
            modelBuilder.Entity<RockPaperSicssorGame>().Property(rps => rps.Result).HasColumnType("tinyint");
            modelBuilder.Entity<Shape>().Property(s => s.TypeOfShape).HasColumnType("tinyint");
        }
    }
}
