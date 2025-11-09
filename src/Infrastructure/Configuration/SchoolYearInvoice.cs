using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SchoolYearInvoiceConfiguration : IEntityTypeConfiguration<SchoolYearInvoice>
{
    public void Configure(EntityTypeBuilder<SchoolYearInvoice> builder)
    {
        builder.ToTable("school_year_invoice");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(x => x.InvoicePeriode)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.SchoolYearStudentId).HasDatabaseName("idx_syi_sys");
        builder.HasIndex(x => x.InvoiceTypeId).HasDatabaseName("idx_syi_pt");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_syi_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_syi_update");
        builder.HasIndex(x => x.DeletedById).HasDatabaseName("idx_syi_del");

        builder.HasOne(x => x.SchoolYearStudent)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.SchoolYearStudentId)
            .HasConstraintName("fk_syi_sys")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.InvoiceType)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.InvoiceTypeId)
            .HasConstraintName("fk_syi_inv_type")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_syi_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_syi_user_update")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasConstraintName("fk_syi_user_del")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
