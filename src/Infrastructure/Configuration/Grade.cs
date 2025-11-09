using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.ToTable("grade");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(x => x.Alphanumeric).HasMaxLength(2);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(x => x.Sub).HasMaxLength(2);

        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.StageId);
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_grade_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_grade_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_grade_del");

        builder.HasOne(x => x.Stage)
            .WithMany(x => x.Grades)
            .HasForeignKey(x => x.StageId)
            .HasConstraintName("fk_grade_stage")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_grade_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_grade_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_grade_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
