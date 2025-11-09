using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Infrastructure.Configuration;

public class SchoolYearStudentNoteDetailConfiguration : IEntityTypeConfiguration<SchoolYearStudentNoteDetail>
{
    public void Configure(EntityTypeBuilder<SchoolYearStudentNoteDetail> builder)
    {
        builder.ToTable("school_year_student_note_detail");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasIndex(x => x.SchoolYearStudentNoteId).HasDatabaseName("idx_sysnd_sysn");
        builder.HasIndex(x => x.NoteTypeId).HasDatabaseName("idx_sysnd_nt");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_sysnd_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_sysnd_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_sysnd_del");

        builder.HasOne(x => x.SchoolYearStudentNote)
            .WithMany(x => x.Details)
            .HasForeignKey(x => x.SchoolYearStudentNoteId)
            .HasConstraintName("fk_sysnd_sysn")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.NoteType)
            .WithMany(x => x.NoteDetails)
            .HasForeignKey(x => x.NoteTypeId)
            .HasConstraintName("fk_sysnd_nt")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_sysnd_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_sysnd_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_sysnd_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
