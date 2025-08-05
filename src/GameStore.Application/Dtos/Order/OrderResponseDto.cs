namespace GameStore.Application.Dtos.Order
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? ShipDate { get; set; }
    }

}
