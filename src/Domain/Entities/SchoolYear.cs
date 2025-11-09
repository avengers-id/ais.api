using System;
using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities;

public class SchoolYear : SoftDeletableEntity<int>
{
    public string Name { get; set; } = null!;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsCurrent { get; set; }

    public ICollection<SchoolYearStudent> SchoolYearStudents { get; set; } = new HashSet<SchoolYearStudent>();
    public ICollection<SchoolCalendar> SchoolCalendars { get; set; } = new HashSet<SchoolCalendar>();
    public ICollection<SchoolSchedule> SchoolSchedules { get; set; } = new HashSet<SchoolSchedule>();
    public ICollection<SchoolGuideline> SchoolGuidelines { get; set; } = new HashSet<SchoolGuideline>();
    public ICollection<InvoiceType> InvoiceTypes { get; set; } = new HashSet<InvoiceType>();
    public ICollection<SchoolYearEmployee> SchoolYearEmployees { get; set; } = new HashSet<SchoolYearEmployee>();
}
