using System.Collections.Generic;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class InvoiceType : SoftDeletableEntity<int>
{
    public int? GenerationId { get; set; }
    public int? SchoolYearId { get; set; }
    public int? StageId { get; set; }
    public string Name { get; set; } = null!;
    public int Amount { get; set; }
    public bool IsMonthly { get; set; }
    public bool IsYearly { get; set; }

    public Generation? Generation { get; set; }
    public SchoolYear? SchoolYear { get; set; }
    public Stage? Stage { get; set; }
    public ICollection<SchoolYearInvoice> Invoices { get; set; } = new HashSet<SchoolYearInvoice>();
}
