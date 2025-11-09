using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Infrastructure.Configuration;

public class RewardTypeConfiguration : IEntityTypeConfiguration<RewardType>
{
    public void Configure(EntityTypeBuilder<RewardType> builder)
    {
        builder.ToTable("reward_type");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_rt_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_rt_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_rt_del");

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_rt_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_rt_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_rt_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
