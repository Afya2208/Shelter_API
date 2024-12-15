using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class FoodAttribute
{
    public int FoodAttributeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<FoodAttribute1> FoodAttribute1s { get; set; } = new List<FoodAttribute1>();
}
