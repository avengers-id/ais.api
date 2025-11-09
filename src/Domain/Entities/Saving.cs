using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities;

public class Saving : AuditableEntity<int>
{
    public int StudentId { get; set; }
    public int Balance { get; set; }

    public Student Student { get; set; } = null!;
    public ICollection<SavingStatement> Statements { get; set; } = new HashSet<SavingStatement>();
}
