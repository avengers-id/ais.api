using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Infrastructure.Configuration;

public class IdentityVerificationConfiguration : IEntityTypeConfiguration<IdentityVerification>
{
    public void Configure(EntityTypeBuilder<IdentityVerification> builder)
    {
        builder.ToTable("identity_verification");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(x => x.Identity)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(x => x.UserId).HasDatabaseName("idx_iv_user");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_iv_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_iv_del");

        builder.HasOne(x => x.User)
            .WithMany(x => x.IdentityVerifications)
            .HasForeignKey(x => x.UserId)
            .HasConstraintName("fk_iv_user")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_iv_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_iv_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
