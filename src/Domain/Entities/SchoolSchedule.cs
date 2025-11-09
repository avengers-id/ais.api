using System;
using Domain.Entities.Common;

namespace Domain.Entities;

public class SchoolSchedule : SoftDeletableEntity<int>
{
    public int? SchoolYearId { get; set; }
    public int? StageId { get; set; }
    public int? GradeId { get; set; }
    public string? Description { get; set; }
    public DateTime? ScheduleDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? FileUrl { get; set; }
    public string? FileName { get; set; }

    public SchoolYear? SchoolYear { get; set; }
    public Stage? Stage { get; set; }
    public Grade? Grade { get; set; }
}
