using System;
using System.Collections.Generic;

namespace DL3C_API.Data.Source;

public partial class BodyComp
{
    public Guid Id { get; set; }

    public Guid? IdBody { get; set; }

    public virtual Body? IdBodyNavigation { get; set; }

    public virtual ICollection<Face> IdFaces { get; } = new List<Face>();
}
