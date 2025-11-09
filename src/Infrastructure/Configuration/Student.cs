using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Infrastructure.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("student");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Nik).HasMaxLength(20);
        builder.Property(x => x.Nis).HasMaxLength(20);
        builder.Property(x => x.Nisn).HasMaxLength(20);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Gender).HasMaxLength(1);
        builder.Property(x => x.BirthPlace).HasMaxLength(150);
        builder.Property(x => x.Nickname).HasMaxLength(150);
        builder.Property(x => x.PreviousSchool).HasMaxLength(150);
        builder.Property(x => x.ProfilePicture).HasMaxLength(1000);
        builder.Property(x => x.FamilyCardNo).HasMaxLength(20);
        builder.Property(x => x.FatherIdNo).HasMaxLength(20);
        builder.Property(x => x.FatherName).HasMaxLength(150);
        builder.Property(x => x.FatherPhoneNo).HasMaxLength(20);
        builder.Property(x => x.FatherEmail).HasMaxLength(20);
        builder.Property(x => x.FatherOccupation).HasMaxLength(150);
        builder.Property(x => x.MotherIdNo).HasMaxLength(20);
        builder.Property(x => x.MotherName).HasMaxLength(150);
        builder.Property(x => x.MotherPhoneNo).HasMaxLength(20);
        builder.Property(x => x.MotherEmail).HasMaxLength(20);
        builder.Property(x => x.MotherOccupation).HasMaxLength(150);
        builder.Property(x => x.CommunicationPhoneNo).HasMaxLength(20);
        builder.Property(x => x.CommunicationEmail).HasMaxLength(50);
        builder.Property(x => x.Address).HasMaxLength(200);
        builder.Property(x => x.Rt).HasMaxLength(3);
        builder.Property(x => x.Rw).HasMaxLength(3);
        builder.Property(x => x.District).HasMaxLength(150);
        builder.Property(x => x.City).HasMaxLength(150);
        builder.Property(x => x.PostalCode).HasMaxLength(6);
        builder.Property(x => x.Distance).HasPrecision(4, 2);
        builder.Property(x => x.LongLat).HasMaxLength(100);

        builder.HasIndex(x => x.Nik).IsUnique();
        builder.HasIndex(x => x.Nis).IsUnique();
        builder.HasIndex(x => x.Nisn).IsUnique();
        builder.HasIndex(x => x.GenerationId).HasDatabaseName("idx_student_gen");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_student_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_student_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_student_del");

        builder.HasOne(x => x.Generation)
            .WithMany(x => x.Students)
            .HasForeignKey(x => x.GenerationId)
            .HasConstraintName("fk_student_gen")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_student_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_student_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_student_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
