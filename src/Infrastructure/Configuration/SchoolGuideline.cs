using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SchoolGuidelineConfiguration : IEntityTypeConfiguration<SchoolGuideline>
{
    public void Configure(EntityTypeBuilder<SchoolGuideline> builder)
    {
        builder.ToTable("school_guideline");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.FileUrl).HasMaxLength(1000);
        builder.Property(x => x.FileName).HasMaxLength(1000);

        builder.HasIndex(x => x.SchoolYearId).HasDatabaseName("idx_sg_sy");
        builder.HasIndex(x => x.StageId).HasDatabaseName("idx_sg_stage");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_sg_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_sg_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_sg_del");

        builder.HasOne(x => x.SchoolYear)
            .WithMany(x => x.SchoolGuidelines)
            .HasForeignKey(x => x.SchoolYearId)
            .HasConstraintName("fk_sg_school_year")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Stage)
            .WithMany(x => x.SchoolGuidelines)
            .HasForeignKey(x => x.StageId)
            .HasConstraintName("fk_sg_stage")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_sg_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_sg_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_sg_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
