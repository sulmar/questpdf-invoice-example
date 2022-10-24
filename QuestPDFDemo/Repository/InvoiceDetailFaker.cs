using Bogus;
using QuestPDFDemo.Domain;

namespace QuestPDFDemo.Repository
{
    public class InvoiceDetailFaker : Faker<InvoiceDetail>
    {
        public InvoiceDetailFaker(Faker<Product> productFaker)
        {
            var products = productFaker.Generate(10);

            RuleFor(p => p.Product, f=>f.PickRandom(products));
            RuleFor(p => p.UnitPrice, (f,p)=>p.Product.Price);
            RuleFor(p => p.Quantity, f => f.Random.Int(1, 10));
        }
    }
}
