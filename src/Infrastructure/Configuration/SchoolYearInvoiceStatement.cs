using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Infrastructure.Configuration;

public class SchoolYearInvoiceStatementConfiguration : IEntityTypeConfiguration<SchoolYearInvoiceStatement>
{
    public void Configure(EntityTypeBuilder<SchoolYearInvoiceStatement> builder)
    {
        builder.ToTable("school_year_invoice_statement");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasIndex(x => x.SchoolYearInvoiceId).HasDatabaseName("idx_syis_syi");
        builder.HasIndex(x => x.CreatedById).HasDatabaseName("idx_syis_create");
        builder.HasIndex(x => x.UpdatedById).HasDatabaseName("idx_syis_update");

        builder.HasOne(x => x.SchoolYearInvoice)
            .WithMany(x => x.Statements)
            .HasForeignKey(x => x.SchoolYearInvoiceId)
            .HasConstraintName("fk_syis_syi")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasConstraintName("fk_syis_user_create")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasConstraintName("fk_syis_user_update")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
