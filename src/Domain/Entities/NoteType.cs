using System.Collections.Generic;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class NoteType : SoftDeletableEntity<int>
{
    public int StageId { get; set; }
    public string Name { get; set; } = null!;

    public Stage Stage { get; set; } = null!;
    public ICollection<SchoolYearStudentNoteDetail> NoteDetails { get; set; } = new HashSet<SchoolYearStudentNoteDetail>();
}
