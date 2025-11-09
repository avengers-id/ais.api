using System.Collections.Generic;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class Employee : SoftDeletableEntity<int>
{
    public string? Nik { get; set; }
    public string Name { get; set; } = null!;
    public string? Nickname { get; set; }
    public string? ProfilePicture { get; set; }
    public string? CommunicationPhoneNo { get; set; }
    public string? CommunicationEmail { get; set; }
    public string? Address { get; set; }
    public string? LongLat { get; set; }

    public ICollection<SchoolYearEmployee> SchoolYearAssignments { get; set; } = new HashSet<SchoolYearEmployee>();
}
