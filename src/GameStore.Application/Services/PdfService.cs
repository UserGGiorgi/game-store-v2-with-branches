using Microsoft.Extensions.Configuration;
using GameStore.Application.Interfaces;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace GameStore.Application.Services
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

            using var writer = new PdfWriter(ms);
            using var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            document.Add(new Paragraph($"Invoice for Order: {orderId}"));
            document.Add(new Paragraph($"User ID: {userId}"));
            document.Add(new Paragraph($"Creation Date: {DateTime.Now:yyyy-MM-dd HH:mm}"));

            var validityDays = _config.GetValue<int>("BankInvoiceSettings:ValidityDays");
            document.Add(new Paragraph($"Valid Until: {DateTime.Now.AddDays(validityDays):yyyy-MM-dd HH:mm}"));
            document.Add(new Paragraph($"Total Amount: {total:C}"));

            document.Close();
            return ms.ToArray();
        }
    }

}
