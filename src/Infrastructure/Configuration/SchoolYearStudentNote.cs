using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SchoolYearStudentNoteConfiguration : IEntityTypeConfiguration<SchoolYearStudentNote>
{
    public void Configure(EntityTypeBuilder<SchoolYearStudentNote> builder)
    {
        builder.ToTable("school_year_student_note");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasIndex(x => x.SchoolYearStudentId).HasDatabaseName("idx_sysn_sy");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_sysn_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_sysn_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_sysn_del");

        builder.HasOne(x => x.SchoolYearStudent)
            .WithMany(x => x.Notes)
            .HasForeignKey(x => x.SchoolYearStudentId)
            .HasConstraintName("fk_sysn_sys")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_sysn_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_sysn_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_sysn_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
