using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class JobPositionMapping : IEntityTypeConfiguration<JobPosition>
    {
        public void Configure(EntityTypeBuilder<JobPosition> builder)
        {
            builder.ToTable("JobPositions");

            builder.HasKey(p => p.JobPositionId);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(p => p.Salary)
                .IsRequired()
                .HasPrecision(8, 2);

            builder.Property(p => p.InsertedAt)
                .IsRequired();

            builder.Property(p => p.UpdatedAt)
                .IsRequired(false);
        }
    }
}
