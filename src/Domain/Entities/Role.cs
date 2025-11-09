using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities;

public class Role : SoftDeletableEntity<int>
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;

    public ICollection<User> Users { get; set; } = new HashSet<User>();
}
