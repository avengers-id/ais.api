using Domain.Entities.Common;

namespace Domain.Entities;

public class SchoolYearEmployee : SoftDeletableEntity<int>
{
    public string Code { get; set; } = null!;
    public int SchoolYearId { get; set; }
    public int StageId { get; set; }
    public int GradeId { get; set; }
    public int EmployeeId { get; set; }

    public SchoolYear SchoolYear { get; set; } = null!;
    public Stage Stage { get; set; } = null!;
    public Grade Grade { get; set; } = null!;
    public Employee Employee { get; set; } = null!;
}
