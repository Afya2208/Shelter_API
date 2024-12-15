using WebApplication2.Entities.shorts;

namespace WebApplication2.Entities
{
    public partial class Client
    {
        public Client(ClientShort clientShort)
        {
            FirstName = clientShort.FirstName;
            LastName = clientShort.LastName;
            Phone = clientShort.Phone;
            Email = clientShort.Email;
            Address = clientShort.Address;
            PostalZip = clientShort.PostalZip;
            Region = clientShort.Region;
            CountryId = clientShort.CountryId;
            Login = clientShort.Login;
            Password = clientShort.Password;
        }
        public void Change(Client otherClient)
        {
            FirstName = otherClient.FirstName;
            LastName = otherClient.LastName;
            Phone =     otherClient.Phone;
            Email = otherClient.Email;
            Address = otherClient.Address;
            PostalZip = otherClient.PostalZip;
            Region = otherClient.Region;
            CountryId = otherClient.CountryId;
            Login = otherClient.Login;
            Password = otherClient.Password;
            Serial = otherClient.Serial;
            Number = otherClient.Number;
            Phone2 = otherClient.Phone2;
            IssuedBy = otherClient.IssuedBy;
            DateOfIssue = otherClient.DateOfIssue;
            OtherContactInfo = otherClient.OtherContactInfo;
            RegistrationAddress = otherClient.RegistrationAddress;
            Photo = otherClient.Photo;
        }
        public void AddEditPassportData(PassportData passport)
        {     
            Address = passport.Address;
            Serial = passport.Serial;
            Number = passport.Number;
            IssuedBy = passport.IssuedBy;
            DateOfIssue = passport.DateOfIssue;
            RegistrationAddress = passport.RegistrationAddress;
            
        }
        public Client()
        {

        }
    }
}
