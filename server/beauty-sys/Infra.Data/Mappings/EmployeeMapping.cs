using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(c => c.EmployeeId);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(c => c.Office)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnType("char(11)");

            builder.Property(c => c.InsertedAt)
                .IsRequired();
        }
    }
}
