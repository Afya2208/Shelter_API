using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class FoodPortion
{
    public int FoodPortionId { get; set; }

    public int? Value { get; set; }

    public string? MeasureUnitName { get; set; }

    public string? MeasureUnitAbbreviation { get; set; }

    public string? Modifier { get; set; }

    public decimal? GramWeight { get; set; }

    public int? SequenceNumber { get; set; }

    public int? MinYearAcquired { get; set; }

    public int? Amount { get; set; }

    public string? Description { get; set; }
}
