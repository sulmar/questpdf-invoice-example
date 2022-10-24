using Bogus;
using QuestPDFDemo.Domain;

namespace QuestPDFDemo.Repository
{
    public class AddressFaker : Faker<Address>
    {
        public AddressFaker()
        {
            RuleFor(p => p.CompanyName, f => f.Company.CompanyName());
            RuleFor(p => p.Street, f => f.Address.StreetName());
            RuleFor(p => p.City, f => f.Address.City());
            RuleFor(p => p.State, f => f.Address.State());
            RuleFor(p => p.Email, f => f.Internet.Email());
            RuleFor(p => p.Phone, f => f.Phone.PhoneNumber());
        }
    }
}
