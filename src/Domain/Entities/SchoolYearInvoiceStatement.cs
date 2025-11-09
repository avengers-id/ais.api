using System;
using Domain.Entities.Common;

namespace Domain.Entities;

public class SchoolYearInvoiceStatement : AuditableEntity<int>
{
    public int SchoolYearInvoiceId { get; set; }
    public DateTime? PaymentDate { get; set; }
    public int Amount { get; set; }
    public int Payment { get; set; }
    public int Balance { get; set; }

    public SchoolYearInvoice SchoolYearInvoice { get; set; } = null!;
}
