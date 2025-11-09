using System;

namespace Boilerplate.Domain.Entities.Common;

public abstract class SoftDeletableEntity<T> : AuditableEntity<T>
{
    public int? DeletedById { get; set; }
    public DateTime? DeletedAt { get; set; }
}
