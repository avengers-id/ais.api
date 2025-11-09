using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Infrastructure.Configuration;

public class InvoiceTypeConfiguration : IEntityTypeConfiguration<InvoiceType>
{
    public void Configure(EntityTypeBuilder<InvoiceType> builder)
    {
        builder.ToTable("invoice_type");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(x => x.GenerationId).HasDatabaseName("idx_it_gen");
        builder.HasIndex(x => x.SchoolYearId).HasDatabaseName("idx_it_sy");
        builder.HasIndex(x => x.StageId).HasDatabaseName("idx_it_stage");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_it_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_it_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_it_del");
        builder.HasIndex(x => new { x.GenerationId, x.SchoolYearId, x.StageId, x.Name })
            .IsUnique()
            .HasDatabaseName("uk_it_sy_stage");

        builder.HasOne(x => x.Generation)
            .WithMany(x => x.InvoiceTypes)
            .HasForeignKey(x => x.GenerationId)
            .HasConstraintName("fk_it_gen")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SchoolYear)
            .WithMany(x => x.InvoiceTypes)
            .HasForeignKey(x => x.SchoolYearId)
            .HasConstraintName("fk_it_sy")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Stage)
            .WithMany(x => x.InvoiceTypes)
            .HasForeignKey(x => x.StageId)
            .HasConstraintName("fk_it_stage")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_it_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_it_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_it_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
