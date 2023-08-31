using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class ProcedureMapping : IEntityTypeConfiguration<Procedure>
    {
        public void Configure(EntityTypeBuilder<Procedure> builder)
        {
            builder.ToTable("Procedures");

            builder.HasKey(e => e.ProcedureId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(e => e.Value)
                .IsRequired()
                .HasPrecision(4, 2);

            builder.Property(e => e.InsertedAt)
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .IsRequired(false);
        }
    }
}
