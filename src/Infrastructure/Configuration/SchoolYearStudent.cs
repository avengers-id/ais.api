using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Infrastructure.Configuration;

public class SchoolYearStudentConfiguration : IEntityTypeConfiguration<SchoolYearStudent>
{
    public void Configure(EntityTypeBuilder<SchoolYearStudent> builder)
    {
        builder.ToTable("school_year_student");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.SchoolYearId).HasDatabaseName("idx_sys_sy");
        builder.HasIndex(x => x.StageId).HasDatabaseName("idx_sys_stage");
        builder.HasIndex(x => x.GradeId).HasDatabaseName("idx_sys_grade");
        builder.HasIndex(x => x.StudentId).HasDatabaseName("idx_sys_student");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_sys_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_sys_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_sys_del");

        builder.HasOne(x => x.SchoolYear)
            .WithMany(x => x.SchoolYearStudents)
            .HasForeignKey(x => x.SchoolYearId)
            .HasConstraintName("fk_sys_school_year")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Stage)
            .WithMany(x => x.SchoolYearStudents)
            .HasForeignKey(x => x.StageId)
            .HasConstraintName("fk_sys_stage")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Grade)
            .WithMany(x => x.SchoolYearStudents)
            .HasForeignKey(x => x.GradeId)
            .HasConstraintName("fk_sys_grade")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Student)
            .WithMany(x => x.SchoolYearStudents)
            .HasForeignKey(x => x.StudentId)
            .HasConstraintName("fk_sys_student")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_sys_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_sys_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_sys_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
