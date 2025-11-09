using System;
using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities;

public class SchoolYearStudentNote : SoftDeletableEntity<int>
{
    public int SchoolYearStudentId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Summary { get; set; }

    public SchoolYearStudent SchoolYearStudent { get; set; } = null!;
    public ICollection<SchoolYearStudentNoteDetail> Details { get; set; } = new HashSet<SchoolYearStudentNoteDetail>();
}
