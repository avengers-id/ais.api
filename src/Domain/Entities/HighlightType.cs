using System.Collections.Generic;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class HighlightType : SoftDeletableEntity<int>
{
    public string Name { get; set; } = null!;

    public ICollection<SchoolHighlight> SchoolHighlights { get; set; } = new HashSet<SchoolHighlight>();
}
