using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SchoolYearEmployeeConfiguration : IEntityTypeConfiguration<SchoolYearEmployee>
{
    public void Configure(EntityTypeBuilder<SchoolYearEmployee> builder)
    {
        builder.ToTable("school_year_employee");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.SchoolYearId).HasDatabaseName("idx_sye_sy");
        builder.HasIndex(x => x.StageId).HasDatabaseName("idx_sye_stage");
        builder.HasIndex(x => x.GradeId).HasDatabaseName("idx_sye_grade");
        builder.HasIndex(x => x.EmployeeId).HasDatabaseName("idx_sye_employee");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_sye_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_sye_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_sye_del");

        builder.HasOne(x => x.SchoolYear)
            .WithMany(x => x.SchoolYearEmployees)
            .HasForeignKey(x => x.SchoolYearId)
            .HasConstraintName("fk_sye_school_year")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Stage)
            .WithMany(x => x.SchoolYearEmployees)
            .HasForeignKey(x => x.StageId)
            .HasConstraintName("fk_sye_stage")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Grade)
            .WithMany(x => x.SchoolYearEmployees)
            .HasForeignKey(x => x.GradeId)
            .HasConstraintName("fk_sye_grade")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Employee)
            .WithMany(x => x.SchoolYearAssignments)
            .HasForeignKey(x => x.EmployeeId)
            .HasConstraintName("fk_sye_employee")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_sye_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_sye_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_sye_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
