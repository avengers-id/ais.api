using System;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class SchoolYearInvoiceStatement : AuditableEntity<int>
{
    public int SchoolYearInvoiceId { get; set; }
    public DateTime? PaymentDate { get; set; }
    public int Amount { get; set; }
    public int Payment { get; set; }
    public int Balance { get; set; }

    public SchoolYearInvoice SchoolYearInvoice { get; set; } = null!;
}
