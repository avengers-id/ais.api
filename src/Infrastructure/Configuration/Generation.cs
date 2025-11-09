using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class GenerationConfiguration : IEntityTypeConfiguration<Generation>
{
    public void Configure(EntityTypeBuilder<Generation> builder)
    {
        builder.ToTable("generation");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_gen_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_gen_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_gen_del");

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_gen_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_gen_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_gen_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
