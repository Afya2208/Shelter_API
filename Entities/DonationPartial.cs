using WebApplication2.Entities.shorts;

namespace WebApplication2.Entities
{
    public partial class Donation
    {
        public Donation()
        {
        }
        public Donation(DonationShort @short)
        {
            DateOfDonation = @short.DateOfDonation;
            ClientId = @short.ClientId;
            FoodId = @short.FoodId;
            Amount = @short.Amount;
        }
    }
}
