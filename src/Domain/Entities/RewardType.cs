using System.Collections.Generic;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class RewardType : SoftDeletableEntity<int>
{
    public string Name { get; set; } = null!;

    public ICollection<Reward> Rewards { get; set; } = new HashSet<Reward>();
}
