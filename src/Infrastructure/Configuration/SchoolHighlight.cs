using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Infrastructure.Configuration;

public class SchoolHighlightConfiguration : IEntityTypeConfiguration<SchoolHighlight>
{
    public void Configure(EntityTypeBuilder<SchoolHighlight> builder)
    {
        builder.ToTable("school_highlight");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.FileUrl).HasMaxLength(1000);
        builder.Property(x => x.FileName).HasMaxLength(1000);

        builder.HasIndex(x => x.HighlightTypeId).HasDatabaseName("idx_sh_type");
        builder.HasIndex(x => x.StageId).HasDatabaseName("idx_sh_stage");
        builder.HasIndex(x => x.GradeId).HasDatabaseName("idx_sh_grade");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_sh_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_sh_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_sh_del");

        builder.HasOne(x => x.HighlightType)
            .WithMany(x => x.SchoolHighlights)
            .HasForeignKey(x => x.HighlightTypeId)
            .HasConstraintName("fk_sh_type")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Stage)
            .WithMany(x => x.SchoolHighlights)
            .HasForeignKey(x => x.StageId)
            .HasConstraintName("fk_sh_stage")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Grade)
            .WithMany(x => x.SchoolHighlights)
            .HasForeignKey(x => x.GradeId)
            .HasConstraintName("fk_sh_grade")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_sh_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_sh_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_sh_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
