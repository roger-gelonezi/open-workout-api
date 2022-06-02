using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
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
