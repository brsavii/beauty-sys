using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class SalonMapping : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            builder.ToTable("Salons");

            builder.HasKey(c => c.SalonId);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(c => c.InsertedAt)
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .IsRequired(false);
        }
    }
}
