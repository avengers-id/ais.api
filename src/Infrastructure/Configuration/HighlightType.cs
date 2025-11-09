using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class HighlightTypeConfiguration : IEntityTypeConfiguration<HighlightType>
{
    public void Configure(EntityTypeBuilder<HighlightType> builder)
    {
        builder.ToTable("highlight_type");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_ht_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_ht_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_ht_del");

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_ht_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_ht_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_ht_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
