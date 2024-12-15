using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class FoodPortion1
{
    public int FoodId { get; set; }

    public int FoodPortionId { get; set; }

    public virtual Food Food { get; set; } = null!;

    public virtual FoodPortion FoodPortion { get; set; } = null!;
}
