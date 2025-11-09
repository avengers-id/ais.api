using System;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class Reward : SoftDeletableEntity<int>
{
    public string Code { get; set; } = null!;
    public int RewardTypeId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Map { get; set; }
    public string? PhoneNo { get; set; }
    public int Point { get; set; }
    public int Value { get; set; }
    public string? ThumbUrl { get; set; }
    public string? ThumbFileName { get; set; }
    public string? FileUrl { get; set; }
    public string? FileName { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public int? Limit { get; set; }
    public int? Available { get; set; }
    public bool IsActive { get; set; }

    public RewardType RewardType { get; set; } = null!;
}
