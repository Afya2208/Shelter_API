namespace WebApplication2.Entities.shorts
{
    public class PassportData
    {


        public string? Serial { get; set; }

        public string? Number { get; set; }

        public string? IssuedBy { get; set; }

        public DateTime? DateOfIssue { get; set; }

        public string? RegistrationAddress { get; set; }

        public string Address { get; set; } = null!;
    }
}
