using System;
using Domain.Entities.Common;

namespace Domain.Entities;

public class SchoolGuideline : SoftDeletableEntity<int>
{
    public int? SchoolYearId { get; set; }
    public int? StageId { get; set; }
    public string Name { get; set; } = null!;
    public string? FileUrl { get; set; }
    public string? FileName { get; set; }
    public string? Description { get; set; }

    public SchoolYear? SchoolYear { get; set; }
    public Stage? Stage { get; set; }
}
