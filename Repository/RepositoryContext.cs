using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configurations;

namespace Repository
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MuscularGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.Entity<MuscularGroup>().HasIndex(e=>e.Name).IsUnique();
            modelBuilder.Entity<Exercise>().HasIndex(e=>e.Name).IsUnique();
        }

        public DbSet<MuscularGroup>? MuscularGroups { get; set; }
        public DbSet<Exercise>? Exercises { get; set; }

    }
}