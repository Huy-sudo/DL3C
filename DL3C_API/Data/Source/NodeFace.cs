using System;
using System.Collections.Generic;

namespace DL3C_API.Data.Source;

public partial class NodeFace
{
    public Guid IdNode { get; set; }

    public Guid IdFace { get; set; }

    public int Seq { get; set; }

    public virtual Face IdFaceNavigation { get; set; } = null!;

    public virtual Node IdNodeNavigation { get; set; } = null!;
}
