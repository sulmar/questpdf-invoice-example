using Bogus;
using QuestPDFDemo.Domain;

namespace QuestPDFDemo.Repository
{
    public class PersonFaker : Faker<Domain.Person>
    {
        public PersonFaker()
        {
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p=>p.LastName,f=>f.Person.LastName);
            RuleFor(p => p.Customer, f => new Customer { Name = "Domain Inc." });
        }
    }
}
