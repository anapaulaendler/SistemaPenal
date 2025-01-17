using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Infra.Data.Configurations;

internal class DayOfWorkConfiguration : IEntityTypeConfiguration<WorkDay>
{
    public void Configure(EntityTypeBuilder<WorkDay> builder)
    {
        builder.ToTable("DaysOfWork").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.PrisonerId).IsRequired();

        builder.Property(x => x.Description).HasColumnName("Description").IsRequired();
        
        builder.HasOne(x => x.Prisoner).WithMany(x => x.DaysOfWork).IsRequired();
    }
}
