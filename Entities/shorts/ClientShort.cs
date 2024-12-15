namespace WebApplication2.Entities.shorts
{
    public class ClientShort
    {
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
    }
}
