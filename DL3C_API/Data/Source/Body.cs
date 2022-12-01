using System;
using System.Collections.Generic;

namespace DL3C_API.Data.Source;

public partial class Body
{
    public Guid Id { get; set; }

    public string? BodyName { get; set; }

    public string? BodyDescription { get; set; }

    public string? Color { get; set; }

    public string? EdgeColor { get; set; }

    public Guid? IdBuilding { get; set; }

    public virtual ICollection<BodyComp> BodyComps { get; } = new List<BodyComp>();

    public virtual Building? IdBuildingNavigation { get; set; }

    public virtual ICollection<Prism> Prisms { get; } = new List<Prism>();
}
