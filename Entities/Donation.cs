using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Donation
{
    public int DonationId { get; set; }

    public DateTime DateOfDonation { get; set; }

    public int ClientId { get; set; }

    public int FoodId { get; set; }

    public int Amount { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Food Food { get; set; } = null!;
}
