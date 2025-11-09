using System.Collections.Generic;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class Stage : SoftDeletableEntity<int>
{
    public string Name { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Whatsapp { get; set; }

    public ICollection<Grade> Grades { get; set; } = new HashSet<Grade>();
    public ICollection<SchoolYearStudent> SchoolYearStudents { get; set; } = new HashSet<SchoolYearStudent>();
    public ICollection<InvoiceType> InvoiceTypes { get; set; } = new HashSet<InvoiceType>();
    public ICollection<SchoolCalendar> SchoolCalendars { get; set; } = new HashSet<SchoolCalendar>();
    public ICollection<NoteType> NoteTypes { get; set; } = new HashSet<NoteType>();
    public ICollection<SchoolHighlight> SchoolHighlights { get; set; } = new HashSet<SchoolHighlight>();
    public ICollection<SchoolSchedule> SchoolSchedules { get; set; } = new HashSet<SchoolSchedule>();
    public ICollection<SchoolGuideline> SchoolGuidelines { get; set; } = new HashSet<SchoolGuideline>();
    public ICollection<SchoolYearEmployee> SchoolYearEmployees { get; set; } = new HashSet<SchoolYearEmployee>();
}
