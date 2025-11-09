using System.Collections.Generic;
using Boilerplate.Domain.Entities.Common;

namespace Boilerplate.Domain.Entities;

public class Generation : SoftDeletableEntity<int>
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;

    public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    public ICollection<InvoiceType> InvoiceTypes { get; set; } = new HashSet<InvoiceType>();
}
