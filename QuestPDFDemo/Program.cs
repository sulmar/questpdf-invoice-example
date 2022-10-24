// See https://aka.ms/new-console-template for more information

using QuestPDF.Previewer;
using QuestPDFDemo.Documents;
using QuestPDFDemo.Domain;
using QuestPDFDemo.Repository;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

IDocument document = Document.Create(container =>
{
    container.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(x => x.FontSize(20));

        page.Header()
            .Text("Hello PDF!")
            .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

        page.Content()
            .PaddingVertical(1, Unit.Centimetre)
            .Column(x =>
            {
                x.Spacing(20);

                x.Item().Text("Hello");
                x.Item().Image(Placeholders.Image(200, 100));
            });

        page.Footer()
            .AlignCenter()
            .Text(x =>
            {
                x.Span("Page ");
                x.CurrentPageNumber();
            });
    });
});

// document.ShowInPreviewer();

document.GeneratePdf("hello.pdf");


IInvoiceRepository invoiceRepository = new FakeInvoiceRepository(new InvoiceFaker(new AddressFaker(), new InvoiceDetailFaker(new ProductFaker())));

var invoice = invoiceRepository.Create();

document = new InvoiceDocument(invoice);


document.ShowInPreviewer();

document.GeneratePdf("invoice.pdf");
