using Domain.Models;
using Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class ConfigContext : DbContext
    {
        public ConfigContext(DbContextOptions<ConfigContext> option) : base(option)
        {
        }

        public DbSet<Customer>? Customer { get; set; }
        public DbSet<Employee>? Employee { get; set; }
        public DbSet<Procedure>? Procedure { get; set; }
        public DbSet<EmployeeProcedure>? EmployeeProcedure { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMapping());
            modelBuilder.ApplyConfiguration(new EmployeeMapping());
            modelBuilder.ApplyConfiguration(new ProcedureMapping());
            modelBuilder.ApplyConfiguration(new EmployeeProcedureMapping());

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeProcedures)
                .WithOne(e => e.Employee);

            modelBuilder.Entity<Procedure>()
                .HasMany(e => e.EmployeeProcedures)
                .WithOne(e => e.Procedure);

            modelBuilder.Entity<EmployeeProcedure>()
                .HasOne(e => e.Procedure)
                .WithMany(e => e.EmployeeProcedures);

            modelBuilder.Entity<EmployeeProcedure>()
                .HasOne(e => e.Employee)
                .WithMany(e => e.EmployeeProcedures);

            base.OnModelCreating(modelBuilder);
        }
    }
}
