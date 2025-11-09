using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SavingStatementConfiguration : IEntityTypeConfiguration<SavingStatement>
{
    public void Configure(EntityTypeBuilder<SavingStatement> builder)
    {
        builder.ToTable("saving_statement");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(14);

        builder.Property(x => x.SavingType)
            .IsRequired()
            .HasMaxLength(6);

        builder.HasIndex(x => x.SavingId).HasDatabaseName("idx_sst_saving");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_sst_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_sst_update");
        builder.HasIndex(x => new { x.SavingId, x.Code })
            .IsUnique()
            .HasDatabaseName("uk_fk_sst");

        builder.HasOne(x => x.Saving)
            .WithMany(x => x.Statements)
            .HasForeignKey(x => x.SavingId)
            .HasConstraintName("fk_sst_saving")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_sst_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_sst_user_update")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
