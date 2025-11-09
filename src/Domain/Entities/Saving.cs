using System.Collections.Generic;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class Saving : AuditableEntity<int>
{
    public int StudentId { get; set; }
    public int Balance { get; set; }

    public Student Student { get; set; } = null!;
    public ICollection<SavingStatement> Statements { get; set; } = new HashSet<SavingStatement>();
}
