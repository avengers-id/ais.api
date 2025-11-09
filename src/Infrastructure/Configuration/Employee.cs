using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Infrastructure.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employee");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Nik).HasMaxLength(20);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Nickname).HasMaxLength(150);
        builder.Property(x => x.ProfilePicture).HasMaxLength(1000);
        builder.Property(x => x.CommunicationPhoneNo).HasMaxLength(20);
        builder.Property(x => x.CommunicationEmail).HasMaxLength(50);
        builder.Property(x => x.Address).HasMaxLength(200);
        builder.Property(x => x.LongLat).HasMaxLength(100);

        builder.HasIndex(x => x.Nik).IsUnique();
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_emp_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_emp_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_emp_del");

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_emp_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_emp_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_emp_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
