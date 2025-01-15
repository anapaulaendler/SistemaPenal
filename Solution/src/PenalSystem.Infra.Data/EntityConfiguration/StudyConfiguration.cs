using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Infra.Data.Configurations;

internal class StudyConfiguration : IEntityTypeConfiguration<Study>
{
    public void Configure(EntityTypeBuilder<Study> builder)
    {
        builder.ToTable("Studies").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.PrisonerId).IsRequired();

        builder.Property(x => x.Counter).HasColumnName("Counter").IsRequired();
        builder.Property(x => x.Subject).HasColumnName("Subject").IsRequired();
        
        builder.HasOne(x => x.Prisoner).WithMany(x => x.Studies).IsRequired();
    }
}
