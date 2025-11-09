using System;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class IdentityVerification : Entity<int>
{
    public int UserId { get; set; }
    public string Code { get; set; } = null!;
    public string Identity { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime? ExpiredAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int? UpdatedById { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? DeletedById { get; set; }
    public DateTime? DeletedAt { get; set; }

    public User User { get; set; } = null!;
}
