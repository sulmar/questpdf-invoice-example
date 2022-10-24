using Bogus;
using QuestPDFDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuestPDFDemo.Repository
{

    public class FakeInvoiceRepository : IInvoiceRepository
    {
        private readonly Faker<Invoice> faker;

        public FakeInvoiceRepository(Faker<Invoice> faker) => this.faker = faker;

        public Invoice Create() => faker.Generate();
    }
}
