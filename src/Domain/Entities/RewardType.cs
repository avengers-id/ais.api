using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities;

public class RewardType : SoftDeletableEntity<int>
{
    public string Name { get; set; } = null!;

    public ICollection<Reward> Rewards { get; set; } = new HashSet<Reward>();
}
