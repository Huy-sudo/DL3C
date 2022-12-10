using System;
using System.Collections.Generic;

namespace DL3C_API.Data.Source;

public partial class Node
{
    public Guid Id { get; set; }

    public double ValueX { get; set; }

    public double ValueY { get; set; }

    public double ValueZ { get; set; }

    public virtual ICollection<NodeFace> NodeFaces { get; } = new List<NodeFace>();
}
