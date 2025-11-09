using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Infrastructure.Configuration;

public class SchoolScheduleConfiguration : IEntityTypeConfiguration<SchoolSchedule>
{
    public void Configure(EntityTypeBuilder<SchoolSchedule> builder)
    {
        builder.ToTable("school_schedule");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.FileUrl).HasMaxLength(1000);
        builder.Property(x => x.FileName).HasMaxLength(1000);

        builder.HasIndex(x => x.SchoolYearId).HasDatabaseName("idx_ss_sy");
        builder.HasIndex(x => x.StageId).HasDatabaseName("idx_ss_stage");
        builder.HasIndex(x => x.GradeId).HasDatabaseName("idx_ss_grade");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_ss_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_ss_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_ss_del");

        builder.HasOne(x => x.SchoolYear)
            .WithMany(x => x.SchoolSchedules)
            .HasForeignKey(x => x.SchoolYearId)
            .HasConstraintName("fk_ss_school_year")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Stage)
            .WithMany(x => x.SchoolSchedules)
            .HasForeignKey(x => x.StageId)
            .HasConstraintName("fk_ss_stage")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Grade)
            .WithMany(x => x.SchoolSchedules)
            .HasForeignKey(x => x.GradeId)
            .HasConstraintName("fk_ss_grade")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_ss_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_ss_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_ss_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
