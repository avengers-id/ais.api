using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class HeroConfiguration : IEntityTypeConfiguration<Hero>
{
    public void Configure(EntityTypeBuilder<Hero> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion<HeroId.EfCoreValueConverter>();
    }
}