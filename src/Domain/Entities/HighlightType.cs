using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities;

public class HighlightType : SoftDeletableEntity<int>
{
    public string Name { get; set; } = null!;

    public ICollection<SchoolHighlight> SchoolHighlights { get; set; } = new HashSet<SchoolHighlight>();
}
