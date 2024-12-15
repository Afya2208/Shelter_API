using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Wcfstatus
{
    public string WfcstatusCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Breed> Breeds { get; set; } = new List<Breed>();
}
