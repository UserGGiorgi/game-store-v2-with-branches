using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Extensions.Configuration;
using GameStore.Application.Interfaces;


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
            var doc = new Document();
            var writer = PdfWriter.GetInstance(doc, ms);

            doc.Open();

            doc.Add(new Paragraph($"Invoice for Order: {orderId}"));
            doc.Add(new Paragraph($"User ID: {userId}"));
            doc.Add(new Paragraph($"Creation Date: {DateTime.Now:yyyy-MM-dd HH:mm}"));
            doc.Add(new Paragraph($"Valid Until: {DateTime.Now.AddDays(_config.GetValue<int>("BankInvoiceSettings:ValidityDays")):yyyy-MM-dd HH:mm}"));
            doc.Add(new Paragraph($"Total Amount: {total:C}"));

            doc.Close();
            return ms.ToArray();
        }
    }

}
