using System;
using System.Collections.Generic;

namespace DL3C_API.Data.Source;

public partial class Building
{
    public Guid Id { get; set; }

    public string? BuildingName { get; set; }

    public string? BuildingAddress { get; set; }

    public string? BuildingDescription { get; set; }

    public virtual ICollection<Body> Bodies { get; } = new List<Body>();
}
