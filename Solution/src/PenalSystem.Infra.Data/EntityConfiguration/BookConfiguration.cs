using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Infra.Data.Configurations;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.PrisonerId).IsRequired();

        builder.Property(x => x.Isbn).HasMaxLength(11).IsFixedLength().IsRequired();
        
        builder.HasOne(x => x.Prisoner).WithMany(x => x.Books).IsRequired();
    }
}
