using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Animal
{
    public int AnimalId { get; set; }

    public string Name { get; set; } = null!;

    public string GenderCode { get; set; } = null!;

    public DateTime DateOfArrival { get; set; }

    public int BreedId { get; set; }

    public virtual Breed Breed { get; set; } = null!;

    public virtual Gender GenderCodeNavigation { get; set; } = null!;

    public virtual ICollection<TakingAnimal> TakingAnimals { get; set; } = new List<TakingAnimal>();
}
