using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class SchedulingMapping : IEntityTypeConfiguration<Scheduling>
    {
        public void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            builder.ToTable("Schedulings");

            builder.HasKey(s => s.SchedulingId);

            builder.Property(s => s.StartDate)
                .IsRequired();

            builder.Property(s => s.CustomerId)
                .IsRequired();

            builder.Property(s => s.EmployeeProcedureId)
                .IsRequired();

            builder.HasOne(s => s.Customer)
                .WithOne(c => c.Scheduling)
                .HasForeignKey<Scheduling>(s => s.SchedulingId);

            builder.HasOne(s => s.EmployeeProcedure)
                .WithOne(e => e.Scheduling)
                .HasForeignKey<Scheduling>(s => s.SchedulingId);

            builder.Property(s => s.InsertedAt)
                .IsRequired();

            builder.Property(s => s.UpdatedAt)
                .IsRequired(false);
        }
    }
}
