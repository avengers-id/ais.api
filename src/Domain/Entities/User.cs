using System;
using System.Collections.Generic;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class User : SoftDeletableEntity<int>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool IsActive { get; set; }
    public int? StudentId { get; set; }
    public int? EmployeeId { get; set; }
    public string Name { get; set; } = null!;
    public int? RoleId { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public DateTime? RefreshAt { get; set; }

    public Role? Role { get; set; }
    public Student? Student { get; set; }
    public Employee? Employee { get; set; }
    public ICollection<IdentityVerification> IdentityVerifications { get; set; } = new HashSet<IdentityVerification>();
}
