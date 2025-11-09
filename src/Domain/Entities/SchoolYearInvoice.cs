using System;
using System.Collections.Generic;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class SchoolYearInvoice : SoftDeletableEntity<int>
{
    public string Code { get; set; } = null!;
    public int SchoolYearStudentId { get; set; }
    public int InvoiceTypeId { get; set; }
    public string InvoicePeriode { get; set; } = null!;
    public int InvoiceAmount { get; set; }
    public int InvoiceBalance { get; set; }
    public DateTime? SettledDate { get; set; }

    public SchoolYearStudent SchoolYearStudent { get; set; } = null!;
    public InvoiceType InvoiceType { get; set; } = null!;
    public ICollection<SchoolYearInvoiceStatement> Statements { get; set; } = new HashSet<SchoolYearInvoiceStatement>();
}
