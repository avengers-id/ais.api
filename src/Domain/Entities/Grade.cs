using System.Collections.Generic;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class Grade : SoftDeletableEntity<int>
{
    public string Code { get; set; } = null!;
    public int StageId { get; set; }
    public string? Alphanumeric { get; set; }
    public string Name { get; set; } = null!;
    public string? Sub { get; set; }

    public Stage Stage { get; set; } = null!;
    public ICollection<SchoolYearStudent> SchoolYearStudents { get; set; } = new HashSet<SchoolYearStudent>();
    public ICollection<SchoolCalendar> SchoolCalendars { get; set; } = new HashSet<SchoolCalendar>();
    public ICollection<SchoolHighlight> SchoolHighlights { get; set; } = new HashSet<SchoolHighlight>();
    public ICollection<SchoolSchedule> SchoolSchedules { get; set; } = new HashSet<SchoolSchedule>();
    public ICollection<SchoolGuideline> SchoolGuidelines { get; set; } = new HashSet<SchoolGuideline>();
    public ICollection<SchoolYearEmployee> SchoolYearEmployees { get; set; } = new HashSet<SchoolYearEmployee>();
}
