using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Infrastructure.Configuration;

public class NoteTypeConfiguration : IEntityTypeConfiguration<NoteType>
{
    public void Configure(EntityTypeBuilder<NoteType> builder)
    {
        builder.ToTable("note_type");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(x => x.StageId).HasDatabaseName("idx_nt_stage");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_nt_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_nt_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_nt_del");
        builder.HasIndex(x => new { x.StageId, x.Name })
            .IsUnique()
            .HasDatabaseName("uk_nt_stage_name");

        builder.HasOne(x => x.Stage)
            .WithMany(x => x.NoteTypes)
            .HasForeignKey(x => x.StageId)
            .HasConstraintName("fk_nt_stage")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_nt_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_nt_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_nt_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
