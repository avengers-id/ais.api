using Domain.Entities.Common;

namespace Domain.Entities;

public class SchoolYearStudentNoteDetail : SoftDeletableEntity<int>
{
    public int SchoolYearStudentNoteId { get; set; }
    public int NoteTypeId { get; set; }
    public string? Note { get; set; }

    public SchoolYearStudentNote SchoolYearStudentNote { get; set; } = null!;
    public NoteType NoteType { get; set; } = null!;
}
