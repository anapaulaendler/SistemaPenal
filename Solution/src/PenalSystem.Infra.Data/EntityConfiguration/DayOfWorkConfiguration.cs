using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PenalSystem.Domain.Models;

namespace PenalSystem.Infra.Data.Configurations;

internal class DayOfWorkConfiguration : IEntityTypeConfiguration<DayOfWork>
{
    public void Configure(EntityTypeBuilder<DayOfWork> builder)
    {
        builder.ToTable("DaysOfWork").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.PrisonerId).IsRequired();

        builder.Property(x => x.Counter).HasColumnName("Counter").IsRequired();
        builder.Property(x => x.Description).HasColumnName("Description").IsRequired();
        
        builder.HasOne(x => x.Prisoner).WithMany(x => x.DaysOfWork).IsRequired();
    }
}
