using System;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class SchoolHighlight : SoftDeletableEntity<int>
{
    public int HighlightTypeId { get; set; }
    public int? StageId { get; set; }
    public int? GradeId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? FileUrl { get; set; }
    public string? FileName { get; set; }

    public HighlightType HighlightType { get; set; } = null!;
    public Stage? Stage { get; set; }
    public Grade? Grade { get; set; }
}
