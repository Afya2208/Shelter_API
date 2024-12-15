using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Client
{
    public int ClientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PostalZip { get; set; } = null!;

    public string Region { get; set; } = null!;

    public int CountryId { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Phone2 { get; set; }

    public string? OtherContactInfo { get; set; }

    public string? Serial { get; set; }

    public string? Number { get; set; }

    public string? IssuedBy { get; set; }

    public DateTime? DateOfIssue { get; set; }

    public string? RegistrationAddress { get; set; }

    public byte[]? Photo { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual ICollection<TakingAnimal> TakingAnimals { get; set; } = new List<TakingAnimal>();
}
