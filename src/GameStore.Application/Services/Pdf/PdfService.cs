using GameStore.Application.Interfaces.Pdf;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.Extensions.Configuration;

namespace GameStore.Application.Services.Pdf
{
    public class PdfService : IPdfService
    {
        private readonly IConfiguration _config;

        public PdfService(IConfiguration config)
        {
            _config = config;
        }

        public byte[] GenerateBankInvoice(Guid userId, Guid orderId, decimal total)
        {
            using var ms = new MemoryStream();
            var writer = new PdfWriter(ms);
            writer.SetCloseStream(false);

            using var pdf = new PdfDocument(writer);
            using var document = new Document(pdf);
            AddInvoiceContent(document, userId, orderId, total);

            return ms.ToArray();
        }
        private void AddInvoiceContent(Document document, Guid userId, Guid orderId, decimal total)
        {
            document.Add(new Paragraph($"Invoice for Order: {orderId}"));
            document.Add(new Paragraph($"User ID: {userId}"));
            document.Add(new Paragraph($"Date: {DateTime.Now:yyyy-MM-dd HH:mm}"));

            var validityDays = _config.GetValue("BankInvoiceSettings:ValidityDays", 30);
            document.Add(new Paragraph($"Valid Until: {DateTime.Now.AddDays(validityDays):yyyy-MM-dd}"));
            document.Add(new Paragraph($"Total: {total:C}"));
        }
    }
}