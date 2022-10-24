using Bogus;
using QuestPDFDemo.Domain;

namespace QuestPDFDemo.Repository
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()));
        }
    }
}
