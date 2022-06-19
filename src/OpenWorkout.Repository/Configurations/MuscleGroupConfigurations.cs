using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenWorkout.Entities;

namespace OpenWorkout.Repository.Configurations
{
    internal class MuscleGroupConfigurations : IEntityTypeConfiguration<MuscleGroup>
    {
        public void Configure(EntityTypeBuilder<MuscleGroup> builder)
        {
            builder.Property(c => c.MuscleGroupName)
                .IsRequired()
                .HasMaxLength(20);
            builder.HasIndex(c => c.MuscleGroupName).IsUnique();
        }
    }
}
