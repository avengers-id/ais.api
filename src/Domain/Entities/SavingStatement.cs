using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class SavingStatement : AuditableEntity<int>
{
    public int SavingId { get; set; }
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public string SavingType { get; set; } = null!;
    public int PreviousBalance { get; set; }
    public int Amount { get; set; }
    public int Balance { get; set; }

    public Saving Saving { get; set; } = null!;
}
