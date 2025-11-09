using System;

namespace Boilerplate.Domain.Entities.Common;

public abstract class AuditableEntity<T> : Entity<T>
{
    public int? CreatedById { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int? UpdatedById { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
