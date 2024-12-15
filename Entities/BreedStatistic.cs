using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class BreedStatistic
{
    public int BreedId { get; set; }

    public byte Temperament { get; set; }

    public byte Activity { get; set; }

    public byte Training { get; set; }

    public byte Longevity { get; set; }

    public byte Height { get; set; }

    public byte Care { get; set; }

    public byte Children { get; set; }

    public byte Apartment { get; set; }

    public byte Guard { get; set; }

    public byte Moult { get; set; }

    public virtual Breed Breed { get; set; } = null!;
}
