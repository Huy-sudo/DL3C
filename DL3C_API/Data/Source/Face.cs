using System;
using System.Collections.Generic;

namespace DL3C_API.Data.Source;

public partial class Face
{
    public Guid Id { get; set; }

    public string FaceName { get; set; } = null!;

    public virtual ICollection<NodeFace> NodeFaces { get; } = new List<NodeFace>();

    public virtual ICollection<Prism> Prisms { get; } = new List<Prism>();

    public virtual ICollection<BodyComp> IdBodyComps { get; } = new List<BodyComp>();
}
