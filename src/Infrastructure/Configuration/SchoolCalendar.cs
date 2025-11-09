using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SchoolCalendarConfiguration : IEntityTypeConfiguration<SchoolCalendar>
{
    public void Configure(EntityTypeBuilder<SchoolCalendar> builder)
    {
        builder.ToTable("school_calendar");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.GcalInvite).HasMaxLength(1000);

        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.SchoolYearId).HasDatabaseName("idx_sc_sy");
        builder.HasIndex(x => x.StageId).HasDatabaseName("idx_sc_stage");
        builder.HasIndex(x => x.GradeId).HasDatabaseName("idx_sc_grade");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_sc_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_sc_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_sc_del");

        builder.HasOne(x => x.SchoolYear)
            .WithMany(x => x.SchoolCalendars)
            .HasForeignKey(x => x.SchoolYearId)
            .HasConstraintName("fk_sc_school_year")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Stage)
            .WithMany(x => x.SchoolCalendars)
            .HasForeignKey(x => x.StageId)
            .HasConstraintName("fk_sc_stage")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Grade)
            .WithMany(x => x.SchoolCalendars)
            .HasForeignKey(x => x.GradeId)
            .HasConstraintName("fk_sc_grade")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_sc_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_sc_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_sc_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
