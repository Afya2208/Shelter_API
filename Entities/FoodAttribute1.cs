using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class FoodAttribute1
{
    public int FoodId { get; set; }

    public int FoodAttributeId { get; set; }

    public virtual Food Food { get; set; } = null!;

    public virtual FoodAttribute FoodAttribute { get; set; } = null!;
}
