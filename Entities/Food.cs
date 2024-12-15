using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Food
{
    public int FoodId { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? FoodClass { get; set; }

    public bool? IsHistoricalReference { get; set; }

    public int? NdbNumber { get; set; }

    public string? FoodCategory { get; set; }

    public int? FdcId { get; set; }

    public DateTime? PublicationDate { get; set; }

    public string? Scientificname { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual FoodAttribute1? FoodAttribute1 { get; set; }
}
