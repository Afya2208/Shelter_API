using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Gender
{
    public string GenderCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
}
