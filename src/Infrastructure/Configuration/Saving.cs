using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SavingConfiguration : IEntityTypeConfiguration<Saving>
{
    public void Configure(EntityTypeBuilder<Saving> builder)
    {
        builder.ToTable("saving");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasIndex(x => x.StudentId).HasDatabaseName("idx_saving_student");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_saving_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_saving_update");

        builder.HasOne(x => x.Student)
            .WithMany(x => x.Savings)
            .HasForeignKey(x => x.StudentId)
            .HasConstraintName("fk_saving_student")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_saving_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_saving_user_update")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
