using Bogus;
using QuestPDFDemo.Domain;

namespace QuestPDFDemo.Repository
{
    public class InvoiceFaker : Faker<Invoice>
    {
        public InvoiceFaker(Faker<Address> addressFaker, Faker<InvoiceDetail> invoiceDetailFaker)
        {
            RuleFor(p => p.InvoiceNumber, f => f.Random.Int(1_000, 2_000));
            RuleFor(p => p.IssueDate, f => f.Date.Recent());
            RuleFor(p => p.DueDate, f => f.Date.Future());
            RuleFor(p => p.SellerAddress, f => addressFaker.Generate());
            RuleFor(p => p.CustomerAddress, f => addressFaker.Generate());
            RuleFor(p => p.Details, f => invoiceDetailFaker.Generate(f.Random.Int(1, 5)));
            RuleFor(p => p.Comments, f => f.Lorem.Paragraph());
            
        }
    }
}
