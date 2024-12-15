using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class InputFood
{
    public int FoodId { get; set; }

    public string? Description { get; set; }

    public int InputFoodId { get; set; }

    public virtual Food Food { get; set; } = null!;

    public virtual Food InputFoodNavigation { get; set; } = null!;
}
