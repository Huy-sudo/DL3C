using System;
using System.Collections.Generic;

namespace DL3C_API.Data.Source;

public partial class Prism
{
    public Guid Id { get; set; }

    public Guid? IdFace { get; set; }

    public double? Height { get; set; }

    public Guid? IdBody { get; set; }

    public virtual Body? IdBodyNavigation { get; set; }

    public virtual Face? IdFaceNavigation { get; set; }
}
