using QuestPDF.Drawing;
using QuestPDFDemo.Domain;
using static System.Net.Mime.MediaTypeNames;

namespace QuestPDFDemo.Documents
{
    public class EventDocument : IDocument
    {
        public Event Model { get; }

        public EventDocument(Event @event)
        {
            Model = @event;
        }

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);

                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.CurrentPageNumber();
                        text.Span(" / ");
                        text.TotalPages();
                    });
                });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(Column =>
                {
                    Column
                        .Item().Text(Model.Title)
                        .FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

                    Column.Item().Text(text =>
                    {
                        text.Span("from: ").SemiBold();
                        text.Span($"{Model.From:d}");
                    });

                    Column.Item().Text(text =>
                    {
                        text.Span("to: ").SemiBold();
                        text.Span($"{Model.To:d}");
                    });
                });

                row.ConstantItem(100).Height(50).Placeholder();
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(20);

                column.Item().Row(row =>
                {
                    row.RelativeItem().Component(new AddressComponent("Organizator", Model.Organizer));
                    row.ConstantItem(50);
                  //  row.RelativeItem().Component(new AddressComponent("For", Model.CustomerAddress));
                });

                column.Item().Element(ComposeTable);

                column.Item().PaddingLeft(5).AlignLeft().Text($"Ilość uczestników: {Model.Members.Count}", TextStyle.Default.SemiBold());

                if (!string.IsNullOrWhiteSpace(Model.Comments))
                    column.Item().PaddingTop(25).Element(ComposeComments);
            });
        }

        void ComposeTable(IContainer container)
        {
           

            var headerStyle = TextStyle.Default.SemiBold();

            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(25);
                     columns.RelativeColumn(3);
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Text("L.p.").Style(headerStyle);
                    header.Cell().Text("Imię i nazwisko").Style(headerStyle);
                    header.Cell().Text("Firma").Style(headerStyle);
                     header.Cell().ColumnSpan(3).PaddingTop(5).BorderBottom(1).BorderColor(Colors.Black);
                });

                

                foreach (var item in Model.Members)
                {
                    table.Cell().Element(CellStyle).Text(Model.Members.IndexOf(item) + 1);
                    table.Cell().Element(CellStyle).Text(item.FullName);                    
                    table.Cell().Element(CellStyle).Text(item.Customer.Name);

                    static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                }
            });
        }

        void ComposeComments(IContainer container)
        {
            container.ShowEntire().Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Comments").FontSize(14).SemiBold();
                column.Item().Text(Model.Comments);
            });
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        
    }

}