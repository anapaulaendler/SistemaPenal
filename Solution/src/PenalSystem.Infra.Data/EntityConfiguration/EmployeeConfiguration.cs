using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PenalSystem.Domain.Models;

namespace PenalSystem.Infra.Data.Configurations;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();

        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.BirthDate).HasColumnName("Birth Date").IsRequired();
        builder.Property(x => x.Cpf).HasColumnName("CPF").HasMaxLength(11).IsFixedLength().IsRequired();
        builder.Property(x => x.Email).HasColumnName("E-mail").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Role).HasColumnName("Role").IsRequired();
        builder.Property(x => x.Password).HasMaxLength(50).IsRequired();
    }
}
