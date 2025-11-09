using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SchoolYearConfiguration : IEntityTypeConfiguration<SchoolYear>
{
    public void Configure(EntityTypeBuilder<SchoolYear> builder)
    {
        builder.ToTable("school_year");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_sy_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_sy_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_sy_del");

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_sy_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_sy_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_sy_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
