using System.Collections.Generic;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class SchoolYearStudent : SoftDeletableEntity<int>
{
    public string Code { get; set; } = null!;
    public int SchoolYearId { get; set; }
    public int StageId { get; set; }
    public int GradeId { get; set; }
    public int StudentId { get; set; }
    public bool IsBlacklisted { get; set; }

    public SchoolYear SchoolYear { get; set; } = null!;
    public Stage Stage { get; set; } = null!;
    public Grade Grade { get; set; } = null!;
    public Student Student { get; set; } = null!;
    public ICollection<SchoolYearInvoice> Invoices { get; set; } = new HashSet<SchoolYearInvoice>();
    public ICollection<SchoolYearStudentNote> Notes { get; set; } = new HashSet<SchoolYearStudentNote>();
}
