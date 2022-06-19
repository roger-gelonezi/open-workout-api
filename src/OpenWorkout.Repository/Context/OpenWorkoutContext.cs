using Microsoft.EntityFrameworkCore;
using OpenWorkout.Entities;

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
    }
}
