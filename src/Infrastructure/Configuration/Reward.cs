using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Infrastructure.Configuration;

public class RewardConfiguration : IEntityTypeConfiguration<Reward>
{
    public void Configure(EntityTypeBuilder<Reward> builder)
    {
        builder.ToTable("reward");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Map).HasMaxLength(1000);
        builder.Property(x => x.PhoneNo).HasMaxLength(20);
        builder.Property(x => x.ThumbUrl).HasMaxLength(1000);
        builder.Property(x => x.ThumbFileName).HasMaxLength(1000);
        builder.Property(x => x.FileUrl).HasMaxLength(1000);
        builder.Property(x => x.FileName).HasMaxLength(1000);

        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.RewardTypeId).HasDatabaseName("idx_reward_type");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_reward_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_reward_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_reward_del");

        builder.HasOne(x => x.RewardType)
            .WithMany(x => x.Rewards)
            .HasForeignKey(x => x.RewardTypeId)
            .HasConstraintName("fk_reward_type")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_reward_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_reward_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_reward_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
