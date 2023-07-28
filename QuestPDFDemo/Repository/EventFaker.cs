using Bogus;
using QuestPDFDemo.Domain;

namespace QuestPDFDemo.Repository
{
    public class EventFaker : Faker<Event>
    {
        public EventFaker(Faker<Domain.Person> faker)
        {
            RuleFor(p => p.Title, f => f.Lorem.Word());
            RuleFor(p => p.From, f => f.Date.Past());
            RuleFor(p => p.To, f => f.Date.Future());
            RuleFor(p => p.Members, f => faker.Generate(f.Random.Int(3, 10)));

            RuleFor(p=>p.Slug, f=>f.Lorem.Slug());  
            RuleFor(p => p.Comments, f => f.Lorem.Sentence());

            RuleFor(p => p.Organizer, f => new Address { CompanyName = "Sulmar", City = "Warszawa", Street = "Erazma Ciołka 10/229", Phone = "609-851-649", Email = "marcin.sulecki@sulmar.pl" });
        }

    }


    
}
