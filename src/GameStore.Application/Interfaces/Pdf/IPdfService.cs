namespace GameStore.Application.Interfaces.Pdf
{
    public interface IPdfService
    {
        byte[] GenerateBankInvoice(Guid userId, Guid orderId, decimal total);
    }
}
