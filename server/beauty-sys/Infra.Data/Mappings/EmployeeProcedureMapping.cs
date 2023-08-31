using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class EmployeeProcedureMapping : IEntityTypeConfiguration<EmployeeProcedure>
    {
        public void Configure(EntityTypeBuilder<EmployeeProcedure> builder)
        {
            builder.ToTable("EmployeesProcedures");

            builder.HasKey(e => e.EmployeeProcedureId);

            builder.Property(e => e.EmployeeId)
                .IsRequired();

            builder.Property(e => e.ProcedureId)
                .IsRequired();

            builder.Property(e => e.InsertedAt)
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .IsRequired(false);
        }
    }
}
