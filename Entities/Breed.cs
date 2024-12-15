using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Breed
{
    public int BreedId { get; set; }

    public string Name { get; set; } = null!;

    public string? Synonym { get; set; }

    public string? Code { get; set; }

    public string? WfcstatusCode { get; set; }

    public string? Group { get; set; }

    public string? Section { get; set; }

    public string? EnglishName { get; set; }

    public string? Variety { get; set; }

    public int? StandartFci { get; set; }

    public int? Rcf { get; set; }

    public string? Urlphoto { get; set; }

    public string? Urlwiki { get; set; }

    public int? YearOfRecognitionFci { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual BreedStatistic? BreedStatistic { get; set; }

    public virtual Wcfstatus? WfcstatusCodeNavigation { get; set; }
}
