using Microsoft.EntityFrameworkCore;
using OpenWorkout.Entities;
using OpenWorkout.Repository.Configurations;

namespace OpenWorkout.Repository.Context
{
    public class OpenWorkoutContext : DbContext
    {
        public DbSet<MuscleGroup> MuscleGroups { get; set; }

        public OpenWorkoutContext(DbContextOptions<OpenWorkoutContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MuscleGroupConfigurations).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
