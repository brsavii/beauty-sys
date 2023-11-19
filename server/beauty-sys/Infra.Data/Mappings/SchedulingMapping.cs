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

            builder.HasOne(s => s.Customer)
                .WithOne(c => c.Scheduling)
                .HasForeignKey<Scheduling>(s => s.CustomerId);

            builder.HasOne(s => s.Employee)
                .WithMany(e => e.Schedulings)
                .HasForeignKey(s => s.EmployeeId);

            builder.HasOne(s => s.Procedure)
                .WithMany(e => e.Schedulings)
                .HasForeignKey(s => s.ProcedureId);

            builder.Property(s => s.InsertedAt)
                .IsRequired();

            builder.Property(s => s.UpdatedAt)
                .IsRequired(false);
        }
    }
}
