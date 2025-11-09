using System;
using Domain.Entities.Common;

namespace Domain.Entities;

public class SchoolCalendar : SoftDeletableEntity<int>
{
    public string Code { get; set; } = null!;
    public int? SchoolYearId { get; set; }
    public int? StageId { get; set; }
    public int? GradeId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? GcalInvite { get; set; }

    public SchoolYear? SchoolYear { get; set; }
    public Stage? Stage { get; set; }
    public Grade? Grade { get; set; }
}
