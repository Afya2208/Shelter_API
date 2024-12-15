using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class TakingAnimal
{
    public int TakingAnimalId { get; set; }

    public int ClientId { get; set; }

    public int AnimalId { get; set; }

    public DateTime DateOfTaking { get; set; }

    public virtual Animal Animal { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;
}
